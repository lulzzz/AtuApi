using AtuApi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels.Models
{
    public class RejectResons
    {
        public int Id { get; set; }
        public int DocId { get; set; }
        public string RejectReason { get; set; }
        public User Rejector { get; set; }
        public int RejectorId { get; set; }
    }
}
