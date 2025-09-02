using Microsoft.AspNetCore.Mvc;
using WAVets2Tech_API.Models;
using Microsoft.EntityFrameworkCore;

namespace WAVets2Tech_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CompanyController : ControllerBase
    {
        private readonly Wavets2TechContext _dbContext;

        public CompanyController(Wavets2TechContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]

        public async Task<IActionResult> Get()
        {
            var company = await _dbContext.Companies.ToListAsync();

            if (company == null || company.Count == 0)
            {
                return NotFound();
            }

            return Ok(company);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (_dbContext.Companies == null)
            {
                return NotFound();
            }

            var company = await _dbContext.Companies.FindAsync(id);
            if (company == null)
            {
                return NotFound();
            }

            return Ok(company);
        }

        [HttpPost]
        public async Task<IActionResult> PostCompany(Company company)
        {
            _dbContext.Companies.Add(company);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompany(int id, Company company)
        {
            if (id != company.InternalId)
            {
                return BadRequest();
            }

            _dbContext.Entry(company).State = EntityState.Modified;

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
        public async Task<IActionResult> DeleteCompanys([FromQuery] List<int> id)
        {
            var company = await _dbContext.Companies
                .Where(s => id.Contains(s.InternalId))
                .ToListAsync();

            if (company == null || company.Count == 0)
            {
                return NotFound("No students found with the provided IDs.");
            }

            _dbContext.Companies.RemoveRange(company);
            await _dbContext.SaveChangesAsync();

            return Ok($"Deleted {company.Count} students.");

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            if (_dbContext.Companies == null)
            {
                return NotFound();
            }
            var company = await _dbContext.Companies.FindAsync(id);
            if (company == null)
            {
                return NotFound();
            }
            _dbContext.Companies.Remove(company);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
