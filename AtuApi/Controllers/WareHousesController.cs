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
    public class WareHousesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public WareHousesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetWareHouses()
        {
            var wareHouses = _unitOfWork.WareHouseRepository.GetWareHouses();
            Request.HttpContext.Response.Headers.Add("Total-Count", wareHouses.Count().ToString());
            return base.Ok(wareHouses);
        }
        [HttpGet("{wareHouseCode}")]
        public IActionResult GetTerritories(string wareHouseCode)
        {
            return Ok(_unitOfWork.WareHouseRepository.GetWareHouse(wareHouseCode));
        }
    }
}