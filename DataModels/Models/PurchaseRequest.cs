using AtuApi.Models;
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
            ObjctTypeId = 1;
        }
        public string CompanyName = "ასოციაცია ატუ";
        public int DocNum { get; set; }
        public DateTime PostingDate { get; set; }
        public DateTime CreategDate { get; set; }
        public DateTime DueDate { get; set; }
        [NotMapped]
        public Project project { get; set; }
        public string ProjectCode { get; set; }
        public string ProjectName { get; set; }
        public int OriginatorId { get; set; }
        public virtual User Creator { get; set; }
        public DocumentType ObjctType { get; set; }
        public int ObjctTypeId { get; set; }
        public string Remarks { get; set; }
        public string Status { get; set; }
        public List<PurchaseRequestRow> Rows { get; set; }
    }
}
