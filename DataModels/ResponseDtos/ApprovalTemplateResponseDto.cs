using AtuApi.Models;
using DataModels.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels.ResponseDtos
{
    public class ApprovalTemplateResponseDto
    {
        public int TemplateCode { get; set; }
        public string TemplateName { get; set; }
        public bool IsActive { get; set; }
        public List<UserDtoResponse> ApprovalEmployees { get; set; }
        public List<UserDtoResponse> Users { get; set; }
        public List<DocumentTypeResponseDto> DocumentTypes { get; set; }
    }
}
