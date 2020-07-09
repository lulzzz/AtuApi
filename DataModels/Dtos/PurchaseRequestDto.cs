using DataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataModels.Dtos
{
    public class PurchaseRequestDto
    {
        public PurchaseRequestDto()
        {
            Rows = new List<PurchaseRequestRow>();
        }
        public string CompanyName = "ასოციაცია ატუ";
        public int DocNum { get; set; }
        public DateTime PostingDate { get; set; }
        public DateTime CreategDate { get; set; }
        public DateTime DueDate { get; set; }
        public string ProjectCode { get; set; }
        public Project Project { get; set; }     
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public List<PurchaseRequestRow> Rows { get; set; }
    }
}
