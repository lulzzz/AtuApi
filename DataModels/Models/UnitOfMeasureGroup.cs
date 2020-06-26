using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels.Models
{
    public class UnitOfMeasureGroup
    {
        public UnitOfMeasureGroup()
        {
            Uoms = new List<UnitOfMeasure>();
        }
        public int UgpEntry { get; set; }
        public string UgpCode { get; set; }
        public string UgpName { get; set; }
        public List<UnitOfMeasure> Uoms { get; set; }
    }
}
