using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PROJECTS_API.Models;
using Microsoft.Data.Sqlite;

namespace PROJECTS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private static List<Job> _jobs = new()
        {
            new Job
            {
                JobId = 1,
                JobTitle = "Web Developer",
                CompanyName = "Tech Solutions",
                Location = "Islamabad",
                SalaryRange = "80,000 - 100,000",
                JobType = "Full Time"
            },

            new Job
            {
                JobId = 2,
                JobTitle = "Graphic Designer",
                CompanyName = "Creative Soft",
                Location = "Lahore",
                SalaryRange = "50,000 - 70,000",
                JobType = "Part Time"
            }
        };

        [HttpGet]
        public IActionResult GetAllJobs()
        {
            return Ok(_jobs);
        }

        [HttpGet("{id}")]
        public IActionResult GetJob(int id)
        {
            var job = _jobs.FirstOrDefault(j => j.JobId == id);

            if (job == null)
            {
                return NotFound();
            }

            return Ok(job);
        }

        [HttpPost]
        public IActionResult CreateJob(Job job)
        {
            job.JobId = _jobs.Count + 1;

            _jobs.Add(job);

            return CreatedAtAction(nameof(GetJob),
                new { id = job.JobId },
                job);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateJob(int id, Job updatedJob)
        {
            var job = _jobs.FirstOrDefault(j => j.JobId == id);

            if (job == null)
            {
                return NotFound();
            }

            job.JobTitle = updatedJob.JobTitle;
            job.CompanyName = updatedJob.CompanyName;
            job.Location = updatedJob.Location;
            job.SalaryRange = updatedJob.SalaryRange;
            job.JobType = updatedJob.JobType;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteJob(int id)
        {
            var job = _jobs.FirstOrDefault(j => j.JobId == id);

            if (job == null)
            {
                return NotFound();
            }

            _jobs.Remove(job);

            return NoContent();
        }
    }
}
  
