using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtuApi.Filters;
using AtuApi.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AtuApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public NotificationsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetPurchaseRequesFilter([FromQuery] NotificationFilter filter)
        {
            var notifications = _unitOfWork.NotificationHistoryRepository.FindAll(
                x => (x.ActiveStatus == filter.ActiveStatus || filter.ActiveStatus == null)
                  && (x.OriginatorId == filter.OriginatorId || filter.OriginatorId == null)
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

            Request.HttpContext.Response.Headers.Add("Total-Count", notifications.Count().ToString());
            return Ok(notifications);
        }
    }
}