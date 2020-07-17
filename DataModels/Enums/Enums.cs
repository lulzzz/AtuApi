using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataModels.Enums
{
    public class Enums
    {
        public enum DocStatuses
        {
            Draft = 1,
            PendingForApproval = 2,
            Approved = 3,
            Rejected = 4,
        };
        public enum NotificationStatuses
        {
            NoAction = 1,
            Approved = 2,
            Rejected = 3
        };
        public enum NotificationWatchStatuses
        {
            Open = 1,
            UnRead = 2,
        };
    }
}
