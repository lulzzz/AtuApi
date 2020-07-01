using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtuApi.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AtuApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public PermissionsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

    
        [HttpGet]
        public IActionResult GetPermissions()
        {
            var permissions = _unitOfWork.PermissionRepository.GetAll();
            Request.HttpContext.Response.Headers.Add("Total-Count", permissions.Count().ToString());
            return Ok(permissions);
        }

    }
}