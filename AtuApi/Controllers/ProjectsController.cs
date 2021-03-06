﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtuApi.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AtuApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProjectsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetProjects()
        {
            var projects = _unitOfWork.ProjectRepository.GetProjects();
            Request.HttpContext.Response.Headers.Add("Total-Count", projects.Count().ToString());
            return base.Ok(projects);
        }
        [HttpGet("{projectCode}")]
        public IActionResult GetTerritories(string projectCode)
        {
            return Ok(_unitOfWork.ProjectRepository.GetProject(projectCode));
        }
    }
}