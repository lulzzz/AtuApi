using DataModels.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels.ResponseDtos
{
    public class DocumentStatusesResponse
    {
        public int DocId { get; set; }
        public DocumentTypeResponseDto ObjetType { get; set; }
        public string Status { get; set; }
        public RejectResonsResponseDto RejectResons { get; set; }
        public int RejectResonsId { get; set; }
    }
}
