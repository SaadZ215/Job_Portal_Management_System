using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PROJECTS_API.Models;
using Microsoft.Data.Sqlite;

namespace PROJECTS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantController : ControllerBase
    {
        private static List<Applicant> _applicants = new()
        {
             new Applicant
            {
                ApplicantId = 001,
                ApplicantName = "Ali Khan",
                Email = "ali@gmail.com",
                Phone = "03001234567",
                AppliedJob = "Web Developer"
            },
               new Applicant
            {
                ApplicantId = 002,
                ApplicantName = "Sara Ahmed",
                Email = "sara@gmail.com",
                Phone = "03111234567",
                AppliedJob = "Graphic Designer"
            }
        };

        [HttpGet]
        public IActionResult GetALLApplicants()
        {
            return Ok(_applicants);
        }

        [HttpGet("{id}")]
        public IActionResult GetApplicant(int id)
        {
            var applicant = _applicants.FirstOrDefault(a => a.ApplicantId == id);

            if (applicant == null)
            {
                return NotFound();
            }

            return Ok(applicant);
        }

        [HttpPost]
        public IActionResult CreateApplicant(Applicant applicant)
        {
            applicant.ApplicantId = _applicants.Count + 1;

            _applicants.Add(applicant);

            return CreatedAtAction(nameof(GetApplicant),
                new { id = applicant.ApplicantId },
                applicant);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateApplicant(int id, Applicant updatedApplicant)
        {
            var applicant = _applicants.FirstOrDefault(a => a.ApplicantId == id);

            if (applicant == null)
            {
                return NotFound();
            }

            applicant.ApplicantName = updatedApplicant.ApplicantName;
            applicant.Email = updatedApplicant.Email;
            applicant.Phone = updatedApplicant.Phone;
            applicant.AppliedJob = updatedApplicant.AppliedJob;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteApplicant(int id)
        {
            var applicant = _applicants.FirstOrDefault(a => a.ApplicantId == id);

            if (applicant == null)
            {
                return NotFound();
            }

            _applicants.Remove(applicant);

            return NoContent();
        }
    }
}
