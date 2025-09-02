using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WAVets2Tech_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;


namespace WAVets2Tech_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly Wavets2TechContext _dbContext;
        private readonly IConfiguration _configuration;
        public AdminController(Wavets2TechContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var admins = await _dbContext.Admins.ToListAsync();

            if (admins == null || admins.Count == 0)
            {
                return NotFound();
            }

            return Ok(admins);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (_dbContext.Admins == null)
            {
                return NotFound();
            }

            var admins = await _dbContext.Admins.FindAsync(id);
            if (admins == null)
            {
                return NotFound();
            }

            return Ok(admins);
        }

        [HttpPost]
        public async Task<IActionResult> PostAdmin(Admin admins)
        {
            _dbContext.Admins.Add(admins);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdmin(int id, Admin admins)
        {
            if (id != admins.InternalId)
            {
                return BadRequest();
            }

            _dbContext.Entry(admins).State = EntityState.Modified;

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

        [HttpDelete()]
        public async Task<IActionResult> DeleteAdmins([FromQuery] List<int> id)
        {
            var admins = await _dbContext.Admins
                .Where(s => id.Contains(s.InternalId))
                .ToListAsync();

            if (admins == null || admins.Count == 0)
            {
                return NotFound("No students found with the provided IDs.");
            }

            _dbContext.Admins.RemoveRange(admins);
            await _dbContext.SaveChangesAsync();

            return Ok();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdmin(int id)
        {
            if (_dbContext.Admins == null)
            {
                return NotFound();
            }
            var admins = await _dbContext.Admins.FindAsync(id);
            if (admins == null)
            {
                return NotFound();
            }
            _dbContext.Admins.Remove(admins);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
