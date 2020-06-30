using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtuApi.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AtuApi.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class UnitOfMeasuresController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UnitOfMeasuresController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [ActionName("GetUnitOfMeasure")]
        public IActionResult GetUnitOfMeasure(int absEntry)
        {
            return Ok(_unitOfWork.UnitOfMeasueRepository.GetUnitOfMeasure(absEntry));
        }
        [HttpGet]
        [ActionName("GetUnitOfMeasureGroup")]
        public IActionResult GetUnitOfMeasureGroup(int grpEntry)
        {
            return Ok(_unitOfWork.UnitOfMeasueGroupRepository.GetUnitOfMeasurGroup(grpEntry));
        }

        [HttpGet]
        [ActionName("GetUnitOfMeasureGroups")]
        public IActionResult GetUnitOfMeasureGroups()
        {
            IEnumerable<DataModels.Models.UnitOfMeasureGroup> uoms = _unitOfWork.UnitOfMeasueGroupRepository.GetUnitOfMeasurGroups();
            Request.HttpContext.Response.Headers.Add("Total-Count", uoms.Count().ToString());
            return base.Ok(uoms);
        }

    }

}