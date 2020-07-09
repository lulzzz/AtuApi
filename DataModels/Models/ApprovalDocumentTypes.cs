using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels.Models
{
    public class ApprovalsDocumentType
    {
        public DocumentType DocumentType { get; set; }
        public int DocumentTypeId { get; set; }
        public ApprovalTemplate ApprovalTemplate { get; set; }
        public int ApprovalTemplateTemplateCode { get; set; }
    }
}
