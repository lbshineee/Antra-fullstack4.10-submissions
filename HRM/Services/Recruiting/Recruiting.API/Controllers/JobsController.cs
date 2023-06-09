using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Recruiting.API.Controllers
{
    // Attribute Routing
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        // 1. add references for ApplicationCore and Infra Projects
        // 2. copy all the DI registrations including DbContext into API project program.cs
        // 3. copy the connection string from MVC appsettings.json to API appsettings.json

        private readonly IJobService _jobService;

        public JobsController(IJobService jobService)
        {
            _jobService = jobService;
        }
        
        // http:localhost/api/jobs/
        [Route("")]
        [HttpGet]
        public async Task<IActionResult> GetAllGobs()
        {
            var jobs = await _jobService.GetAllJobs();

            if (!jobs.Any())
            {
                // no jobs exists, then return http status code, 404 notfound
                return NotFound(new { error = " No open Jobs found, please try again later" });
            }
            // return Json data, and also HTTP status codes
            // serialization, converting C# objects into Json Objects using System.Text.Json
            return Ok(jobs);
        }

        // http:localhost/api/jobs/4
        [HttpGet]
        [Route("{id:int}", Name = "GetJobDetails")]
        public async Task<IActionResult> GetJobDetails(int id)
        {
            var job = await _jobService.GetJobById((id));
            if (job == null)
            {
                return NotFound(new { errorMessage = " No Job found for this id" });
            }

            return Ok(job);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Create(JobRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                // 400 status code
                return BadRequest();
            }

            var job = await _jobService.AddJob(model);
            return CreatedAtAction
                ("GetJobDetails", new { controller = "Jobs", id = job }, "Job Created");

        }
    
    }
}