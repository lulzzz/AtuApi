using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels.ResponseDtos
{
    public class ApproverLevelsResponse
    {
        public int UserId { get; set; }
        public int UserLevel { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
    }
}
