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
        public int? ObjectTypeId { get; set; }
        public int? OriginatorId { get; set; } 
        public NotificationWatchStatus? WatchStatus { get; set; }
        public NotificationStatus? ApproverStatus { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedTime { get; set; }     
        public int? ApproverId { get; set; }

    }
}
