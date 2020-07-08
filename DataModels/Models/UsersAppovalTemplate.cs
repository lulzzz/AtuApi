using AtuApi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels.Models
{
    public class UsersAppovalTemplate
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int ApprovalTemplateTemplateCode { get; set; }
        public ApprovalTemplate ApprovalTemplate { get; set; }
    }
}
