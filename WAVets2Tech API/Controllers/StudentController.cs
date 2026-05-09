using Microsoft.AspNetCore.Mvc;
using WAVets2Tech_API.Models;
using Microsoft.EntityFrameworkCore;

namespace WAVets2Tech_API.Controllers
{
    /// <summary>
    /// REST API controller for veteran student profiles.
    /// Supports full CRUD: retrieve, create, update, and delete students.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly Wavets2TechContext _dbContext;

        public StudentController(Wavets2TechContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET /api/student — Return all student profiles
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var students = await _dbContext.Students.ToListAsync();

            if (students == null || students.Count == 0)
            {
                return NotFound("No student profiles found.");
            }

            return Ok(students);
        }

        // GET /api/student/{id} — Return a single student by primary key
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var student = await _dbContext.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound($"No student found with ID {id}.");
            }

            return Ok(student);
        }

        // PUT /api/student/{id} — Update an existing student profile
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(int id, Student student)
        {
            // Ensure the route id matches the body's id to prevent accidental overwrites
            if (id != student.InternalId)
            {
                return BadRequest("Route ID does not match the student ID in the request body.");
            }

            _dbContext.Entry(student).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                // Re-throw so global error handling or middleware can log it
                throw;
            }

            return Ok();
        }

        // POST /api/student — Add a new student profile
        [HttpPost]
        public async Task<IActionResult> PostStudent(Student student)
        {
            _dbContext.Students.Add(student);
            await _dbContext.SaveChangesAsync();

            return Ok(student);
        }

        // DELETE /api/student?id=1&id=2 — Remove multiple students by ID list
        [HttpDelete]
        public async Task<IActionResult> DeleteStudents([FromQuery] List<int> id)
        {
            var students = await _dbContext.Students
                .Where(s => id.Contains(s.InternalId))
                .ToListAsync();

            if (students == null || students.Count == 0)
            {
                return NotFound("No students found with the provided IDs.");
            }

            _dbContext.Students.RemoveRange(students);
            await _dbContext.SaveChangesAsync();

            return Ok($"Deleted {students.Count} student(s).");
        }

        // DELETE /api/student/{id} — Remove a single student by ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _dbContext.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound($"No student found with ID {id}.");
            }

            _dbContext.Students.Remove(student);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
