using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtuApi.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AtuApi.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class ItemWarehouseController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ItemWarehouseController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [ActionName("GetItemInfo")]
        public IActionResult GetItemInfo(string itemCode)
        {
            return Ok(_unitOfWork.ItemsWarehousesRepository.GetItemInfoWarehouses(itemCode));
        }
        [HttpGet]
        [ActionName("GetItemInfoInWareHouse")]
        public IActionResult GetItemInfoInWareHouse(string itemCode, string wareHouseCode)
        {
            return Ok(_unitOfWork.ItemsWarehousesRepository.GetItemInfoInWareHouse(itemCode, wareHouseCode));
        } 
    }
}