using AtuApi.Interfaces;
using DataContextHelper;
using DataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtuApi.Repositories
{
    public class NotificationHistoryRepository : Repository<NotificationsHistory>, INotificationHistoryRepository
    {
        public NotificationHistoryRepository(DataContext context) : base(context)
        {
        }
        private DataContext NotificationHistory => Context as DataContext;
    }
}
