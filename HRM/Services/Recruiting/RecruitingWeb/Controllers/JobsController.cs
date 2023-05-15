using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Contracts.Services;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RecruitingWeb.Controllers
{
    public class JobsController : Controller
    {
        private readonly IJobService _jobService;

        // Constructor Dependency Injection
        public JobsController(IJobService jobService)
        {
            _jobService = jobService;
        }
        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            // return all the jobs so that candidates can apply to the job
            // we need to get list of Jobs
            //  call the Job Service
            
            var jobs = _jobService.GetAllJobs();
            return View();
        }

        // get the Job detailed information by ID
        [HttpGet]
        public IActionResult Details(int id)
        {
            // get job by ID
           
            var job = _jobService.GetJobById(id);
            return View();
        }

        // Authenticated and User should have role for creating new Job
        // HR/Manager
        [HttpPost]
        public IActionResult Create()
        {
            // take the information from the View and save to DB
            return View();
        }
    }
}

