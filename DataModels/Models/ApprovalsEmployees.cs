using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataModels.Models
{
    public class ApprovalsEmployees
    {
        public int ApprovalCode { get; set; }
        [NotMapped]
        public virtual ApprovalTemplate ApprovalTemplate { get; set; }
        public int EmployeeCode { get; set; }
        [NotMapped]
        public virtual Employee Employee { get; set; }

    }
}
