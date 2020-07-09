using DataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataModels.RequestDtos
{
    public class ApprovalTemplateRequestDto
    {
        public int TemplateCode { get; set; }
        public string TemplateName { get; set; }
        public bool IsActive { get; set; }
        public List<int> Approvers { get; set; }
        public List<int> Originators { get; set; }
        public List<int> DocumentTypes { get; set; }
    }
}
