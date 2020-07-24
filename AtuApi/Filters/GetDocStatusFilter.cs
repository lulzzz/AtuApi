using DataModels.Models;
using DataModels.ResponseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static DataModels.Enums.Enums;

namespace AtuApi.Filters
{
    public class GetDocStatusFilter : IFilter
    {

        #nullable enable
        public List<int>? ObjectTypeId { get; set; }
        public List<int>? OriginatorId { get; set; } 
        public NotificationWatchStatus? WatchStatus { get; set; }
        public NotificationStatus? ApproverStatus { get; set; }
        public DateTime CreateDateStart { get; set; }
        public DateTime CreateDateEnd { get; set; }
        public DateTime ModifiedTime { get; set; }     
        public List<int>? ApproverId { get; set; }

    }
}
