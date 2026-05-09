using Microsoft.AspNetCore.Mvc;
using WAVets2Tech_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace WAVets2Tech_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployerController : ControllerBase
    {
        private readonly Wavets2TechContext _dbContext;
        private readonly IConfiguration _configuration;
        public EmployerController(Wavets2TechContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]

        public async Task<IActionResult> Get()
        {
            var employers = await _dbContext.Employers.ToListAsync();

            if (employers == null || employers.Count == 0)
            {
                return NotFound();
            }

            return Ok(employers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (_dbContext.Employers == null)
            {
                return NotFound();
            }

            var employers = await _dbContext.Employers.FindAsync(id);
            if (employers == null)
            {
                return NotFound();
            }

            return Ok(employers);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployer(int id, Employer employers)
        {
            if (id != employers.InternalId)
            {
                return BadRequest();
            }

            _dbContext.Entry(employers).State = EntityState.Modified;

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
        public async Task<IActionResult> PostEmployer(Employer employers)
        {
            _dbContext.Employers.Add(employers);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }


        [HttpDelete()]
        public async Task<IActionResult> DeleteEmployers([FromQuery] List<int> id)
        {
            var employer = await _dbContext.Employers
                .Where(s => id.Contains(s.InternalId))
                .ToListAsync();

            if (employer == null || employer.Count == 0)
            {
                return NotFound("No employer found with the provided IDs.");
            }

            _dbContext.Employers.RemoveRange(employer);
            await _dbContext.SaveChangesAsync();

            return Ok($"Deleted {employer.Count} employer.");

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployer(int id)
        {
            if (_dbContext.Employers == null)
            {
                return NotFound();
            }
            var employer = await _dbContext.Employers.FindAsync(id);
            if (employer == null)
            {
                return NotFound();
            }
            _dbContext.Employers.Remove(employer);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
