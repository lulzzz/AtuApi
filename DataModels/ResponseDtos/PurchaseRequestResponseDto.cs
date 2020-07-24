using DataModels.Models;
using DataModels.RequestDtos;
using System;
using System.Collections.Generic;
using System.Text;
using static DataModels.Enums.Enums;

namespace DataModels.ResponseDtos
{
    public class PurchaseRequestResponseDto
    {
        public PurchaseRequestResponseDto()
        {
            Rows = new List<PurchaseRequestResponseRowDto>();
        }
        public string CompanyName = "ასოციაცია ატუ";
        public int DocNum { get; set; }
        public DateTime PostingDate { get; set; }
        public DateTime CreategDate { get; set; }
        public DateTime DueDate { get; set; }
        public string ProjectCode { get; set; }
        public Project Project { get; set; }
        public int OriginatorId { get; set; }
        public string OriginatonFullName { get; set; }
        public UserDtoResponse Originator { get; set; }
        public UserDtoResponse Creator { get; set; }
        public int CreatorId { get; set; }
        public DocumentTypeResponseDto ObjctType { get; set; }
        public DocStatus Status { get; set; }
        public List<PurchaseRequestResponseRowDto> Rows { get; set; }
    }
}
