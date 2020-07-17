using AtuApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using static DataModels.Enums.Enums;

namespace DataModels.Models
{
    public class NotificationsHistory
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Comment { get; set; }
        public User Approver { get; set; }
        public int ApproverId { get; set; }
        public User Orignator { get; set; }
        public int OrignatorId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedTime { get; set; }
        public NotificationWatchStatuses WatchStatus { get; set; }
        public NotificationStatuses ApproverStatus { get; set; }
        public int ObjectTypeId { get; set; }
        public DocumentType ObjectType { get; set; }
        public int Level { get; set; }
        public int DocId { get; set; }
    }
}
