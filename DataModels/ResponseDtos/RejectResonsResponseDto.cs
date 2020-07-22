using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels.ResponseDtos
{
    public class RejectResonsResponseDto
    {
        public int Id { get; set; }
        public int DocId { get; set; }
        public string RejectReason { get; set; }
        public UserDtoResponse Rejector { get; set; }
        public int RejectorId { get; set; }
    }
}
