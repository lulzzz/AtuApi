using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using AtuApi.Filters;
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
using static DataModels.Enums.Enums;

namespace AtuApi.Controllers
{
    [Route("api/[controller]/[Action]")]
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
            purchaseRequest.DocNum = 0;
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
            return CreatedAtAction(nameof(GetPurchaseRequests), new { id = res.DocNum }, res.DocNum);
        }

        [HttpPost]
        public IActionResult PostPurchaseRequest(int docNum)
        {
            var purchaseRequest = _unitOfWork.PurchaseRequestRepository.Get(docNum);
            IEnumerable<ApprovalTemplate> listOfApprovalTemplates = _unitOfWork.ApprovalTemplateRepository.GetAll();
            IList<ApprovalTemplateResponseDto> listOfApprovalTemplateDtos = _mapper.Map<IList<ApprovalTemplateResponseDto>>(listOfApprovalTemplates);

            var listOfApproversDtosWithOriginator = listOfApprovalTemplates.Where(x => x.UsersAppovalTemplates.Any(x => x.UserId == purchaseRequest.Creator.Id)).SelectMany(x => x.ApprovalsEmployees).OrderBy(x => x.UserLevel);

            if (listOfApproversDtosWithOriginator.Count() < 1)
            {
                listOfApproversDtosWithOriginator = listOfApprovalTemplates.Where(x => x.IsActive).SelectMany(x => x.ApprovalsEmployees).OrderBy(x => x.UserLevel);
            }

            foreach (var user in listOfApproversDtosWithOriginator)
            {
                NotificationsHistory history = new NotificationsHistory
                {
                    OriginatorId = purchaseRequest.Creator.Id,
                    ApproverId = user.UserId,
                    CreateDate = DateTime.Now,
                    DocId = docNum,
                    ModifiedTime = DateTime.Now,
                    ObjectTypeId = purchaseRequest.ObjctTypeId,
                    Level = user.UserLevel,
                    Text = $"დოკუმენტი დასადასტურებელია : {purchaseRequest.ObjctType.DocDescription} : {docNum}",
                    WatchStatus = NotificationWatchStatus.UnRead,
                    ApproverStatus = NotificationStatus.NoAction,
                    ActiveStatus = NotificationActiveStatus.Activated
                };
                _unitOfWork.NotificationHistoryRepository.Add(history);
            }
            return Accepted();
        }

        [HttpGet]
        public IActionResult GetPurchaseRequests()
        {
            IEnumerable<PurchaseRequest> purchaseReqests = _unitOfWork.PurchaseRequestRepository.GetAll();
            IEnumerable<PurchaseRequestResponseDto> PurchaseRequetDtos = _mapper.Map<IEnumerable<PurchaseRequestResponseDto>>(purchaseReqests);
            Request.HttpContext.Response.Headers.Add("Total-Count", purchaseReqests.Count().ToString());
            return Ok(PurchaseRequetDtos);
        }

        [HttpGet]
        public IActionResult GetPurchaseRequesFilter([FromQuery] PurchaseRequestFilter filter)
        {
            IEnumerable<PurchaseRequest> purchaseReqests = _unitOfWork.PurchaseRequestRepository.GetAll().Where(x => (x.Status == filter.docStatus || filter.docStatus == null) && (x.OriginatorId == filter.OriginatorId 
           || filter.OriginatorId == null) && (x.CreatorId == filter.CreatorId || filter.CreatorId == null));

            IEnumerable<PurchaseRequestResponseDto> PurchaseRequetDtos = _mapper.Map<IEnumerable<PurchaseRequestResponseDto>>(purchaseReqests);
            Request.HttpContext.Response.Headers.Add("Total-Count", purchaseReqests.Count().ToString());
            return Ok(PurchaseRequetDtos);
        }


        [HttpGet("{id}")]
        public IActionResult GetPurchaseRequest(int id)
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

        [HttpPut]
        public IActionResult ModifyPurchaseRequest(PurchaseRequestRequestDto purchaseRequestDto)
        {
            var purchaseRequest = _mapper.Map<PurchaseRequest>(purchaseRequestDto);
            var purchaseRequestDb = _unitOfWork.PurchaseRequestRepository.Get(purchaseRequestDto.DocNum);
            var originator = _unitOfWork.UserRepository.GetById(purchaseRequestDto.OriginatorId);
            var originatorDto = _mapper.Map<UserDtoResponse>(originator);
            var creator = _unitOfWork.UserRepository.GetById(int.Parse(User.Identity.Name));
            var project = _unitOfWork.ProjectRepository.GetProject(purchaseRequestDto.ProjectCode);


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
            purchaseRequestDb.Creator = creator;
            purchaseRequestDb.ProjectName = project.ProjectName;
            var rowsDto = _mapper.Map<IList<PurchaseRequestRow>>(purchaseRequestDto.Rows).ToList();
            purchaseRequestDb.Rows = rowsDto;
            purchaseRequestDb.Status = purchaseRequestDto.Status;
            PurchaseRequest res = _unitOfWork.PurchaseRequestRepository.Update(purchaseRequestDb);



            var notificationByDoc = _unitOfWork.NotificationHistoryRepository.FindAll(x => x.DocId == res.DocNum);
            var rejectedNotification = notificationByDoc.First(x => x.ApproverStatus == NotificationStatus.Rejected);

          
            foreach (var not in notificationByDoc)
            {
                not.ActiveStatus = NotificationActiveStatus.Deactivated;                 
                _unitOfWork.NotificationHistoryRepository.Update(not);
            }

            IEnumerable<ApprovalTemplate> listOfApprovalTemplates = _unitOfWork.ApprovalTemplateRepository.GetAll();
            IList<ApprovalTemplateResponseDto> listOfApprovalTemplateDtos = _mapper.Map<IList<ApprovalTemplateResponseDto>>(listOfApprovalTemplates);

            var listOfApproversDtosWithOriginator = listOfApprovalTemplates.Where(x => x.UsersAppovalTemplates.Any(x => x.UserId == res.Creator.Id)).SelectMany(x => x.ApprovalsEmployees).OrderBy(x => x.UserLevel);

            if (listOfApproversDtosWithOriginator.Count() < 1)
            {
                listOfApproversDtosWithOriginator = listOfApprovalTemplates.Where(x => x.IsActive).SelectMany(x => x.ApprovalsEmployees).OrderBy(x => x.UserLevel);
            }

            foreach (var user in listOfApproversDtosWithOriginator)
            {
                NotificationsHistory history = new NotificationsHistory
                {
                    OriginatorId = res.Creator.Id,
                    ApproverId = user.UserId,
                    CreateDate = DateTime.Now,
                    DocId = res.DocNum,
                    ModifiedTime = DateTime.Now,
                    ObjectTypeId = purchaseRequest.ObjctTypeId,
                    Level = user.UserLevel,
                    Text = $"დოკუმენტი დასადასტურებელია : {res.ObjctType.DocDescription} : {res.DocNum}",
                    WatchStatus = NotificationWatchStatus.UnRead,
                    ApproverStatus = NotificationStatus.NoAction,
                    ActiveStatus = NotificationActiveStatus.Activated
                };
                _unitOfWork.NotificationHistoryRepository.Add(history);
            }


            return CreatedAtAction(nameof(GetPurchaseRequests), new { id = res.DocNum }, res.DocNum);
        }

    }
}