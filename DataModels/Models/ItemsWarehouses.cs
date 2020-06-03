using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels.Models
{
    public class ItemsWarehouses
    {
        public ItemsWarehouses()
        {
            itemWareHouses = new List<ItemWareHouse>();
        }
        public string ItemCode { get; set; }
        public double TotalInStock { get; set; }
        public ICollection<ItemWareHouse> itemWareHouses { get; set; }


    }
}
