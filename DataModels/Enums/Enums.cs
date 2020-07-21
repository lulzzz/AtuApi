using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataModels.Enums
{
    public class Enums
    {
        public enum DocStatus
        {
            Draft = 0,
            PendingForApproval = 1,
            Approved = 2,
            Rejected = 3,
        };
        public enum NotificationStatus
        {
            NoAction = 0,
            Approved = 1,
            Rejected = 2,
        };
        public enum NotificationActiveStatus
        {
            Deactivated = 0,
            Activated = 1,
        };
        public enum NotificationWatchStatus
        {
            Open = 0,
            UnRead = 1,
        };
    }
}
