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
        [ActionName("GetItemQuantity")]
        public IActionResult GetItemQuantity(string itemCode)
        {
            return Ok(_unitOfWork.ItemsWarehousesRepository.GetItemQuantityWarehouses(itemCode));
        }
        [HttpGet]
        [ActionName("GetItemQuantityInWareHouse")]
        public IActionResult GetItemQuantityInWareHouse(string itemCode, string wareHouseCode)
        {
            return Ok(_unitOfWork.ItemsWarehousesRepository.GetItemQuantityInWarehouse(itemCode, wareHouseCode));
        }
    }
}