using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels.Models
{
    public class BusinessPartner
    {
        public string CardCode { get; set; }
        public string CardName { get; set; }
        public string FederalTaxId { get; set; }
        public int GroupCode { get; set; }
        public string GroupName { get; set; }
    }
}
