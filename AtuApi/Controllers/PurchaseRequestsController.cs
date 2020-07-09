using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
 
using AtuApi.Interfaces;
using AutoMapper;
using DataModels.Dtos;
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
            var project = _unitOfWork.ProjectRepository.GetProject(purchaseRequestDto.ProjectCode); 
            if (emp == null)
            {
                return UnprocessableEntity($"EmployeeId : {purchaseRequestDto.EmployeeId} არ არსებობს");
            }
            if (project == null)
            {
                return UnprocessableEntity($"ProjectCode : {purchaseRequestDto.ProjectCode} არ არსებობს");
            }
            foreach (var row in purchaseRequest.Rows)
            {
                var bp = _unitOfWork.BusinessPartnerRepository.GetBusinessPartner(row.BusinessPartnerCode);
                var item = _unitOfWork.ItemRepository.GetItem(row.ItemCode);
                var territory = _unitOfWork.TerritoryRepository.GetTerritory(row.TeritoryId);
                var wareHouse = _unitOfWork.WareHouseRepository.GetWareHouse(row.WareHouse);
                if (bp == null)
                {
                    return UnprocessableEntity($"BusinessPartner : {row.BusinessPartnerCode} არ არსებობს");
                }
                if (item == null)
                {
                    return UnprocessableEntity($"item : {row.ItemCode} არ არსებობს");
                }
                if (territory == null)
                {
                    return UnprocessableEntity($"territory : {row.TeritoryId} არ არსებობს");
                }
                if (wareHouse == null)
                {
                    return UnprocessableEntity($"wareHouse : {row.WareHouse} არ არსებობს");
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
            Request.HttpContext.Response.Headers.Add("Total-Count", purchaseReqests.Count().ToString());
            return Ok(PurchaseRequetDtos);
        }

        [HttpGet("{id}")]
        public IActionResult GetPurchaseReques(int id)  
        {
            PurchaseRequest purchaseReqests = _unitOfWork.PurchaseRequestRepository.Get(id);
            purchaseReqests.Employee = _unitOfWork.EmployeeRepository.GetEmployee(purchaseReqests.EmployeeId);
            purchaseReqests.project = _unitOfWork.ProjectRepository.GetProject(purchaseReqests.ProjectCode);    
            PurchaseRequestDto PurchaseRequestDto = _mapper.Map<PurchaseRequestDto>(purchaseReqests);
            return Ok(PurchaseRequestDto);
        }
    }
}