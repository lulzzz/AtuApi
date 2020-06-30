using AtuApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataModels.Models
{
    public class ApprovalTemplate
    {
        public int TemplateCode { get; set; }
        public string TemplateName { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public ICollection<ApprovalsEmployees> ApprovalsEmployees { get; set; }

    }
}
