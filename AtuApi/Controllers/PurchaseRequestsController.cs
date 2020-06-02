﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtuApi.Dtos;
using AtuApi.Interfaces;
using AutoMapper;
using DataModels.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AtuApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseRequestsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public PurchaseRequestsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult CreatePurchaseRequest(PurchaseRequestDto purchaseRequestDto)
        {
            var purchaseRequest = _mapper.Map<PurchaseRequest>(purchaseRequestDto);
            var emp = _unitOfWork.EmployeeRepository.GetEmployee(purchaseRequestDto.EmployeeId);
            if (emp == null)
            {
                return UnprocessableEntity($"EmployeeId : {purchaseRequestDto.EmployeeId} არ არსებობს");
            }
            foreach (var row in purchaseRequest.Rows)
            {
                var bp = _unitOfWork.BusinessPartnerRepository.GetBusinessPartner(row.BusinessPartnerCode);
                var item = _unitOfWork.ItemRepository.GetItem(row.ItemCode);
                if (bp == null)
                {
                    return UnprocessableEntity($"BusinessPartner : {row.BusinessPartnerCode} არ არსებობს");
                }
                if (item == null)
                {
                    return UnprocessableEntity($"item : {row.ItemCode} არ არსებობს");
                }
            }
            var res = _unitOfWork.PurchaseRequestRepository.Add(purchaseRequest);
            return Accepted(res.DocNum);
        }

        [HttpGet]
        public IActionResult GetPurchaseReques()
        {
            IEnumerable<PurchaseRequest> purchaseReqests = _unitOfWork.PurchaseRequestRepository.GetAll();
            IEnumerable<PurchaseRequestDto> PurchaseRequetDtos = _mapper.Map<IEnumerable<PurchaseRequestDto>>(purchaseReqests);
            return Ok(PurchaseRequetDtos);
        }

        [HttpGet("{id}")]
        public IActionResult GetPurchaseReques(int id)  
        {
            PurchaseRequest purchaseReqests = _unitOfWork.PurchaseRequestRepository.Get(id);
            PurchaseRequestDto PurchaseRequestDto = _mapper.Map<PurchaseRequestDto>(purchaseReqests);
            return Ok(PurchaseRequestDto);
        }
    }
}