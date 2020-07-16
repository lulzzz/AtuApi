using DataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataModels.ResponseDtos
{
    public class PurchaseRequestResponseRowDto
    {
        public string ItemCode { get; set; }
        public Item Item { get; set; }
        public string BusinessPartnerCode { get; set; }
        public BusinessPartner BusinessPartner { get; set; }
        public double RequiredQuantity { get; set; }
        public DateTime DueDate { get; set; }
        public int TeritoryId { get; set; }
        public Territory Teritory { get; set; }
        public double InStockTotal { get; set; }
        public double InStockInWhs { get; set; }
        public string WareHouseCode { get; set; }
        public WareHouse WareHouse { get; set; }
        public int DocNum { get; set; }
        public int LineNum { get; set; }
    }
}
