using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels.Models
{
    public class Territory
    {
        public int TerritoryId { get; set; }
        public string Description { get; set; }
        public int Parent { get; set; }
        public int Lindex { get; set; }
        public string Inactive { get; set; }
    }
}
