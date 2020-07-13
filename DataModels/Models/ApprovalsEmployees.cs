using AtuApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataModels.Models
{
    public class ApprovalsEmployees
    {
        public int ApprovalTemplateTemplateCode { get; set; }
        public virtual ApprovalTemplate ApprovalTemplate { get; set; }
        public int UserId { get; set; }
        public int UserLevel { get; set; }
        public virtual User User { get; set; }

    }
}
