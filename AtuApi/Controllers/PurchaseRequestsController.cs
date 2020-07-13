using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtuApi.Helpers;
using AtuApi.Interfaces;
using AutoMapper;
using DataModels.Dtos;
using DataModels.Models;
using DataModels.RequestDtos;
using DataModels.ResponseDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic.CompilerServices;

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
        public IActionResult CreatePurchaseRequest(PurchaseRequestRequestDto purchaseRequestDto)
        {
            var purchaseRequest = _mapper.Map<PurchaseRequest>(purchaseRequestDto);
            var originator = _unitOfWork.UserRepository.GetById(purchaseRequestDto.OriginatorId);
            var originatorDto = _mapper.Map<UserDtoResponse>(originator);
            var creator = _unitOfWork.UserRepository.GetById(int.Parse(User.Identity.Name));
            var project = _unitOfWork.ProjectRepository.GetProject(purchaseRequestDto.ProjectCode);
            purchaseRequest.Creator = creator;
            purchaseRequest.ProjectName = project.ProjectName;

            if (originator == null)
            {
                return UnprocessableEntity($"originatorId : {purchaseRequestDto.OriginatorId} არ არსებობს");
            }
            if (project == null)
            {
                return UnprocessableEntity($"ProjectCode : {purchaseRequestDto.ProjectCode} არ არსებობს");
            }
            foreach (var row in purchaseRequestDto.Rows)
            {
                var bp = _unitOfWork.BusinessPartnerRepository.GetBusinessPartner(row.BusinessPartnerCode);
                var item = _unitOfWork.ItemRepository.GetItem(row.ItemCode);
                var territory = _unitOfWork.TerritoryRepository.GetTerritory(row.TeritoryId);
                var wareHouse = _unitOfWork.WareHouseRepository.GetWareHouse(row.WareHouseCode);
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
                    return UnprocessableEntity($"wareHouse : {row.WareHouseCode} არ არსებობს");
                }
            }

            PurchaseRequest res = _unitOfWork.PurchaseRequestRepository.Add(purchaseRequest);

            if (res.DocNum != 0)
            {
                IEnumerable<ApprovalTemplate> listOfApprovalTemplates = _unitOfWork.ApprovalTemplateRepository.GetAll();
                IList<ApprovalTemplateResponseDto> listOfApprovalTemplateDtos = _mapper.Map<IList<ApprovalTemplateResponseDto>>(listOfApprovalTemplates);


                var listOfApproversDtosWithOriginator = listOfApprovalTemplateDtos.Where(x => x.Originators.Any(x => x.Id == originator.Id)).SelectMany(x => x.Approvers);

                foreach (var user in listOfApproversDtosWithOriginator)
                {
                    NotificationsHistory history = new NotificationsHistory
                    {
                        OrignatorId = originator.Id,
                        ApproverId = user.Id,
                        CreateDate = DateTime.Now,
                        DocId = res.DocNum,
                        ModifiedTime = DateTime.Now,
                        ObjectTypeId = res.ObjctType.Id,
                        Text = $"დოკუმენტი დასადასტურებელია : {res.ObjctType.DocDescription} : {res.DocNum}",
                        Status = "UnRead"
                    };
                    _unitOfWork.NotificationHistoryRepository.Add(history);
                }
            }
            var xz22 = nameof(GetPurchaseReques);
            var xz = CreatedAtAction(nameof(GetPurchaseReques), new { id = res.DocNum }, res.DocNum);
            var urlx = Url.Link(nameof(GetPurchaseReques), new { id = res.DocNum });
            var urlx2 = Url.Link(nameof(GetPurchaseReques), res.DocNum);


            return CreatedAtAction(nameof(GetPurchaseReques), new { id = res.DocNum }, res.DocNum);
        }

        [HttpGet]
        public IActionResult GetPurchaseReques()
        {
            IEnumerable<PurchaseRequest> purchaseReqests = _unitOfWork.PurchaseRequestRepository.GetAll();
            IEnumerable<PurchaseRequestResponseDto> PurchaseRequetDtos = _mapper.Map<IEnumerable<PurchaseRequestResponseDto>>(purchaseReqests);
            Request.HttpContext.Response.Headers.Add("Total-Count", purchaseReqests.Count().ToString());
            return Ok(PurchaseRequetDtos);
        }

        [HttpGet("{id}")]
        public IActionResult GetPurchaseReques(int id)
        {
            PurchaseRequest purchaseReqests = _unitOfWork.PurchaseRequestRepository.Get(id);
            if (purchaseReqests == null)
            {
                NotFound();
            }

            PurchaseRequestResponseDto PurchaseRequestDto = _mapper.Map<PurchaseRequestResponseDto>(purchaseReqests);
            PurchaseRequestDto.Project = _unitOfWork.ProjectRepository.GetProject(purchaseReqests.ProjectCode);
            PurchaseRequestDto.Originator = _mapper.Map<UserDtoResponse>(_unitOfWork.UserRepository.GetById(purchaseReqests.OriginatorId));
            PurchaseRequestDto.Originator.Permissions = new List<PermissionDto>();
            foreach (var rowDto in PurchaseRequestDto.Rows)
            {
                rowDto.BusinessPartner = _unitOfWork.BusinessPartnerRepository.GetBusinessPartner(rowDto.BusinessPartnerCode);
                rowDto.Teritory = _unitOfWork.TerritoryRepository.GetTerritory(rowDto.TeritoryId);
                rowDto.WareHouse = _unitOfWork.WareHouseRepository.GetWareHouse(rowDto.WareHouseCode);
                rowDto.Item = _unitOfWork.ItemRepository.GetItem(rowDto.ItemCode);
            }



            return Ok(PurchaseRequestDto);
        }
    }
}