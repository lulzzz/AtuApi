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
    public class BusinessPartnersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public BusinessPartnersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetBusinessPartners()
        {
            var businessPartners = _unitOfWork.BusinessPartnerRepository.GetBusinessPartners();
            Request.HttpContext.Response.Headers.Add("Total-Count", businessPartners.Count().ToString());
            return Ok(businessPartners);
        }

        [HttpGet("{cardCode}")]
        public IActionResult GetBusinessPartner(string cardCode)
        {
            var BusinessPartner = _unitOfWork.BusinessPartnerRepository.GetBusinessPartner(cardCode);
            return BusinessPartner == null ? NotFound() : (IActionResult)Ok(BusinessPartner);
        }
    }
}