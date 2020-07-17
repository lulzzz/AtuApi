using AtuApi.Models;
using DataModels.Dtos;
using DataModels.Models;
using DataModels.RequestDtos;
using DataModels.ResponseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static DataModels.Enums.Enums;

namespace DataModels.RequestDtos
{
    public class PurchaseRequestRequestDto
    {
        public PurchaseRequestRequestDto()
        {
            Rows = new List<PurchaseRequestRequestRowDto>();

        }

        public int DocNum { get; set; }
        public DocStatuses Status { get; set; }

        public string CompanyName = "ასოციაცია ატუ";
        public DateTime PostingDate { get; set; }
        public DateTime CreategDate { get; set; }
        public DateTime DueDate { get; set; }
        public string ProjectCode { get; set; }
        public int OriginatorId { get; set; }
        public List<PurchaseRequestRequestRowDto> Rows { get; set; }
    }
}
