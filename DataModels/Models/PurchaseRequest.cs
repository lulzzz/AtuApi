using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataModels.Models
{
    public class PurchaseRequest
    {
        public PurchaseRequest()
        {
            Rows = new List<PurchaseRequestRow>();
        }
        public string CompanyName = "ასოციაცია ატუ";
        public int DocNum { get; set; }
        public DateTime PostingDate { get; set; }
        public DateTime CreategDate { get; set; }
        public DateTime DueDate { get; set; }
        public string ProjectCode { get; set; }
        public string ProjectName { get; set; }
        [NotMapped]
        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }
        public List<PurchaseRequestRow> Rows { get; set; }
    }
}
