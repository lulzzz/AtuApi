using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtuApi.Interfaces;
using AutoMapper;
using DataModels.Dtos;
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
        private readonly IMapper _mapper;
        public PermissionsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

    
        [HttpGet]
        public IActionResult GetPermissions()
        {
            var permissions = _unitOfWork.PermissionRepository.GetAll();
            var permissionsDto = _mapper.Map<List<PermissionDto>>(permissions);
            Request.HttpContext.Response.Headers.Add("Total-Count", permissionsDto.Count().ToString());
            return Ok(permissionsDto);
        }

    }
}