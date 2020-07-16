using AtuApi.Interfaces;
using DataContextHelper;
using DataModels.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace AtuApi.Repositories
{
    public class NotificationHistoryRepository : Repository<NotificationsHistory>, INotificationHistoryRepository
    {
        public NotificationHistoryRepository(DataContext context) : base(context)
        {
        }
        public new IEnumerable<NotificationsHistory> FindAll(Expression<Func<NotificationsHistory, bool>> predicate)
        {
           return NotificationHistoryContext.NotificationsHistory.Where(predicate).Include(x=>x.Orignator).Include(x=>x.ObjectType).ToList();
        }
        private DataContext NotificationHistoryContext => Context as DataContext;
    }
}
