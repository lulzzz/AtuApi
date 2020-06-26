using DataModels.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels
{
    public class Item
    {
        public Item()
        {
            UnitOfMeasures = new List<UnitOfMeasure>();
        }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string UnitOfMeasurePurchaseCode { get; set; }
        public string UnitOfMeasurePurchaseName { get; set; }
        public IEnumerable<UnitOfMeasure> UnitOfMeasures { get; set; }
    }
}
