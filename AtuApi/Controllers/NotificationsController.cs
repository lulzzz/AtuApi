using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtuApi.Filters;
using AtuApi.Interfaces;
using AutoMapper;
using DataModels.Models;
using DataModels.ResponseDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AtuApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public NotificationsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetPurchaseRequesFilter([FromQuery] NotificationFilter filter)
        {
            IEnumerable<NotificationsHistory> notifications = _unitOfWork.NotificationHistoryRepository.FindAll(
                x => (x.ActiveStatus == filter.ActiveStatus || filter.ActiveStatus == null)
                  && (x.OriginatorId == filter.OriginatorId || filter.OriginatorId == null)
                  && (x.Id == filter.Id || filter.Id == null)
                  && (x.ApproverId == filter.ApproverId || filter.ApproverId == null)
                  && (x.ApproverStatus == filter.ApproverStatus || filter.ApproverStatus == null)
                  && (x.Comment == filter.Comment || filter.Comment == null)
                  && (x.DocId == filter.DocId || filter.DocId == null)
                  && (x.Level == filter.Level || filter.Level == null)
                  && (x.WatchStatus == filter.WatchStatus || filter.WatchStatus == null)
                  && (x.RejectedResons.Id == filter.RejectedResonId || filter.RejectedResonId == null)
                  && (x.OriginatorId == filter.RejectedResonId || filter.RejectedResonId == null)
                  && (x.CreateDate.Year == filter.CreateDate.Year && x.CreateDate.Month == filter.CreateDate.Month && x.CreateDate.DayOfYear == filter.CreateDate.DayOfYear || filter.CreateDate == DateTime.MinValue)
                  );
            var notificationDtos = _mapper.Map<IList<NotificationsHistoryDto>>(notifications);
            Request.HttpContext.Response.Headers.Add("Total-Count", notifications.Count().ToString());
            return Ok(notificationDtos);
        }
    }
}