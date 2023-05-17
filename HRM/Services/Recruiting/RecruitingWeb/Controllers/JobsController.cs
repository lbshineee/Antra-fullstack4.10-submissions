﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
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
        public async Task< IActionResult> Index()
        {
            // return all the jobs so that candidates can apply to the job
            // we need to get list of Jobs
            //  call the Job Service
            
            
            // database
            // I/O bound operation
            // CPU bound operation
            
            // 3 ways we can send data from controller/actionb method to view
            //  1. ViewBag
            //  2. ViewData
            
            //  3. *** Strongly Typed Model data ***
            ViewBag.PageTitle = "Showing JObs";
            var jobs = await _jobService.GetAllJobs();
            return View(jobs);
        }

        // get the Job detailed information by ID
        [HttpGet]
        public async Task< IActionResult> Details(int id)
        {
            // get job by ID
           
            var job = await _jobService.GetJobById(id);
            return View(job);
        }

        // Authenticated and User should have role for creating new Job
        // HR/Manager
        
        // Show the empty page
        [HttpGet]
        public IActionResult Create()
        {
            // take the information from the View and save to DB
            return View();
        }

        // Saving the Job Information
        //  The process of getting the data from the browser and mapping to the model object, is called
        // Model Binding in asp.net core
        //  Model binding is not case sensitive
        [HttpPost]
        public async Task<IActionResult> Create(JobRequestModel model)
        {
            // check if the model is valid, on the server 
            if (!ModelState.IsValid)
            {
                return View();
            }
            // save the data in the database
            // return to the index View
            await _jobService.AddJob(model);
            return RedirectToAction("Index");
        }
    }
}

