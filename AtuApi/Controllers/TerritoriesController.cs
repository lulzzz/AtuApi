using System;
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
    public class TerritoriesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public TerritoriesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetTerritories()
        {
            IEnumerable<DataModels.Models.Territory> territories = _unitOfWork.TerritoryRepository.GetTerritories();
            Request.HttpContext.Response.Headers.Add("Total-Count", territories.Count().ToString());
            return base.Ok(territories);
        }

        [HttpGet("{territoryId}")]
        public IActionResult GetTerritories(int territoryId)
        {
            return Ok(_unitOfWork.TerritoryRepository.GetTerritory(territoryId));
        }

    }
}