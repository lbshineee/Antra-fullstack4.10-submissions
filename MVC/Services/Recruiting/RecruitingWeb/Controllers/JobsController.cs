﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RecruitingWeb.Controllers
{
    public class JobsController : Controller
    {
        [HttpGet]   // This is called attributes in C#
        public IActionResult Index()
        {
            // return all the jobs so that candidates can apply to thte job
            return View();
        }

        // get the Job detailed inforamtion
        [HttpGet]
        public IActionResult Details(int id)
        {
            return View();
        }

        // Authenticated and User should have role for creating new Job
        // HR, Manager
        [HttpPost]
        public IActionResult Create()
        {
            // take the information from the View and save to DB
            return View();
        }
    }
}

