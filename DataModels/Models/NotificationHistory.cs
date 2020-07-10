using AtuApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataModels.Models
{
    public class NotificationsHistory
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public User Approver { get; set; }
        public int ApproverId { get; set; }
        public User Orignator { get; set; }
        public int OrignatorId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedTime { get; set; }
        public string Status { get; set; }
        public int ObjectTypeId { get; set; }
        public DocumentType ObjectType { get; set; } 
        public int DocId { get; set; }
    }
}
