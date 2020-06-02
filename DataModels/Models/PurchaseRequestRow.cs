﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataModels.Models
{
    public class PurchaseRequestRow
    {
        [NotMapped]
        public Item Item { get; set; }
        public string ItemCode { get; set; }
        [NotMapped]
        public BusinessPartner BusinessPartner { get; set; }
        public string BusinessPartnerCode { get; set; }
        public double RequiredQuantity { get; set; }
        public DateTime DueDate { get; set; }
        public Territory Teritory { get; set; }
        public string Remarks { get; set; }
        public double InStockTotal { get; set; }
        public double InStockInWhs { get; set; }
        public string WareHouse { get; set; }
        public string Status { get; set; }
        public int PurchaseRequestDocNum { get; set; }
        public int LineNum { get; set; }
    }
}