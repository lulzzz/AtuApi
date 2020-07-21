using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static DataModels.Enums.Enums;

namespace AtuApi.Filters
{
    public class PurchaseRequestFilter : IFilter
    {
        public DocStatus? docStatus { get; set; }
        public int? OriginatorId { get; set; }
        public int? CreatorId { get; set; }
    }
}
