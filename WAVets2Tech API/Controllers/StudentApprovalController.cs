using Microsoft.AspNetCore.Mvc;
using WAVets2Tech_API.Models;
using Microsoft.EntityFrameworkCore;

namespace WAVets2Tech_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentApprovalController : ControllerBase
    {
        private readonly Wavets2TechContext _dbContext;

        public StudentApprovalController(Wavets2TechContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]

        public async Task<IActionResult> Get()
        {
            var students = await _dbContext.StudentApprovals.ToListAsync();

            if (students == null || students.Count == 0)
            {
                return NotFound();
            }

            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (_dbContext.Students == null)
            {
                return NotFound();
            }

            var students = await _dbContext.StudentApprovals.FindAsync(id);
            if (students == null)
            {
                return NotFound();
            }

            return Ok(students);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(int id, StudentApproval student)
        {
            if (id != student.InternalId)
            {
                return BadRequest();
            }

            _dbContext.Entry(student).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> PostStudent(StudentApproval student)
        {
            _dbContext.StudentApprovals.Add(student);
            await _dbContext.SaveChangesAsync();

            return Ok();

        }

        [HttpDelete()]
        public async Task<IActionResult> DeleteStudents([FromQuery] List<int> id)
        {
            var students = await _dbContext.StudentApprovals
                .Where(s => id.Contains(s.InternalId))
                .ToListAsync();

            if (students == null || students.Count == 0)
            {
                return NotFound("No students found with the provided IDs.");
            }

            _dbContext.StudentApprovals.RemoveRange(students);
            await _dbContext.SaveChangesAsync();

            return Ok($"Deleted {students.Count} students.");

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            if (_dbContext.StudentApprovals == null)
            {
                return NotFound();
            }

            var students = await _dbContext.StudentApprovals.FindAsync(id);
            if (students == null)
            {
                return NotFound("No students found with the provided IDs.");
            }

            _dbContext.StudentApprovals.Remove(students);
            await _dbContext.SaveChangesAsync();

            return Ok();

        }
    }
}
