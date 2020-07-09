using System.Collections.Generic;

namespace DataModels.Models
{
    public class DocumentType
    {
        public int Id { get; set; }
        public string DocDescription { get; set; }
        public List<ApprovalsDocumentType> ApprovalDocumentTypes { get; set; }
    }
}