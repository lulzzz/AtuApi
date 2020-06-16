using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels.Models
{
    public class ItemWareHouse
    {
        public string WareHouseCode { get; set; }
        public double OnHand { get; set; }
        public double IsCommited { get; set; }
        public double Cost { get; set; }
    }
}
