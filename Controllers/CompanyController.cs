using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PROJECTS_API.Models;
using Microsoft.Data.Sqlite;

namespace PROJECTS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private static List<Company> _companies = new()
        {
            new Company
            {
                CompanyId = 1,
                CompanyName = "Tech Solutions",
                Location = "Islamabad"
            },

            new Company
            {
                CompanyId = 2,
                CompanyName = "Creative Soft",
                Location = "Lahore"
            }
        };

        [HttpGet]
        public IActionResult GetAllCompanies()
        {
            return Ok(_companies);
        }

        [HttpGet("{id}")]
        public IActionResult GetCompany(int id)
        {
            var company = _companies.FirstOrDefault(c => c.CompanyId == id);

            if (company == null)
            {
                return NotFound();
            }

            return Ok(company);
        }

        [HttpPost]
        public IActionResult CreateCompany(Company company)
        {
            company.CompanyId = _companies.Count + 1;

            _companies.Add(company);

            return CreatedAtAction(nameof(GetCompany),
                new { id = company.CompanyId },
                company);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCompany(int id, Company updatedCompany)
        {
            var company = _companies.FirstOrDefault(c => c.CompanyId == id);

            if (company == null)
            {
                return NotFound();
            }

            company.CompanyName = updatedCompany.CompanyName;
            company.Location = updatedCompany.Location;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCompany(int id)
        {
            var company = _companies.FirstOrDefault(c => c.CompanyId == id);

            if (company == null)
            {
                return NotFound();
            }

            _companies.Remove(company);

            return NoContent();
        }
    }
}
