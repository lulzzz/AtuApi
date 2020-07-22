using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static DataModels.Enums.Enums;

namespace AtuApi.Filters
{
    public class NotificationFilter : IFilter
    {
        public int? Id { get; set; }
        public string Text { get; set; }
        public string Comment { get; set; }
        public int? ApproverId { get; set; }
        public int? OriginatorId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedTime { get; set; }
        public NotificationWatchStatus? WatchStatus { get; set; }
        public NotificationStatus? ApproverStatus { get; set; }
        public int? ObjectTypeId { get; set; }
        public int? Level { get; set; }
        public int? DocId { get; set; }
        public NotificationActiveStatus? ActiveStatus { get; set; }
        public int? RejectedResonId { get; set; }
    }
}
