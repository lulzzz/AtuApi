using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels.RequestDtos
{
    public class PurchaseRequestRequestRowDto
    {
        public string ItemCode { get; set; }
        public string BusinessPartnerCode { get; set; }
        public double RequiredQuantity { get; set; }
        public DateTime DueDate { get; set; }
        public int TeritoryId { get; set; }
        public string TeritoryDescription { get; set; }
        public string Remarks { get; set; }
        public double InStockTotal { get; set; }
        public double InStockInWhs { get; set; }
        public string WareHouseCode { get; set; }
        public string Status { get; set; }
        public int DocNum { get; set; }
        public int LineNum { get; set; }
    }
}
