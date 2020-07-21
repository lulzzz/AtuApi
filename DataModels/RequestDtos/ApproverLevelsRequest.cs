using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels.RequestDtos
{
    public class ApproverLevelsRequest
    {
        public int UserId { get; set; }
        public int UserLevel { get; set; }
    }
}
