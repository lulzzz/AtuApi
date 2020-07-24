using DataModels.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels.ResponseDtos
{
    public class NotificationsHistoryDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public UserDtoResponse Approver { get; set; }
        public int ApproverId { get; set; }
        public UserDtoResponse Orignator { get; set; }
        public int OrignatorId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedTime { get; set; }
        public string WatchStatus { get; set; }
        public string ApproverStatus { get; set; }
        public int ObjectTypeId { get; set; }
        public DocumentTypeResponseDto ObjectType { get; set; }
        public int Level { get; set; }
        public string Comment { get; set; }
        public int DocId { get; set; }
    }
}
