using Microsoft.AspNetCore.Mvc;
using WAVets2Tech_API.Models;
using Microsoft.EntityFrameworkCore;

namespace WAVets2Tech_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployerApprovalController : ControllerBase
    {
        private readonly Wavets2TechContext _dbContext;

        public EmployerApprovalController(Wavets2TechContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]

        public async Task<IActionResult> Get()
        {
            var students = await _dbContext.EmployerApprovals.ToListAsync();

            if (students == null || students.Count == 0)
            {
                return NotFound();
            }

            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (_dbContext.EmployerApprovals == null)
            {
                return NotFound();
            }

            var students = await _dbContext.EmployerApprovals.FindAsync(id);
            if (students == null)
            {
                return NotFound();
            }

            return Ok(students);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(int id, EmployerApproval student)
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
        public async Task<IActionResult> PostStudent(EmployerApproval student)
        {
            _dbContext.EmployerApprovals.Add(student);
            await _dbContext.SaveChangesAsync();

            return Ok();

        }

        [HttpDelete()]
        public async Task<IActionResult> DeleteStudents([FromQuery] List<int> id)
        {
            var students = await _dbContext.EmployerApprovals
                .Where(s => id.Contains(s.InternalId))
                .ToListAsync();

            if (students == null || students.Count == 0)
            {
                return NotFound("No students found with the provided IDs.");
            }

            _dbContext.EmployerApprovals.RemoveRange(students);
            await _dbContext.SaveChangesAsync();

            return Ok($"Deleted {students.Count} students.");

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            if (_dbContext.EmployerApprovals == null)
            {
                return NotFound();
            }

            var students = await _dbContext.EmployerApprovals.FindAsync(id);
            if (students == null)
            {
                return NotFound("No students found with the provided IDs.");
            }

            _dbContext.EmployerApprovals.Remove(students);
            await _dbContext.SaveChangesAsync();

            return Ok();

        }
    }
}
