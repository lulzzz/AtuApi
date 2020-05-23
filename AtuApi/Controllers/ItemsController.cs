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
    public class ItemsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ItemsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetItems()
        {            
            return Ok(_unitOfWork.ItemRepository.GetItems());
        }

        [HttpGet("{itemCode}")]
        public IActionResult GetItem(string itemCode)
        {
            var item = _unitOfWork.ItemRepository.GetItem(itemCode);
            return item == null ? NotFound() : (IActionResult)Ok(item);
        }
    }
}