using DataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtuApi.Dtos
{               
    public class ApprovalTemplateDto
    {
        public int TemplateCode { get; set; }
        public string TemplateName { get; set; }
        public bool IsActive { get; set; }
        public List<int> ApprovalEmployees { get; set; }
    }
}
