using DataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtuApi.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Position { get; set; }
        public virtual Role Role { get; set; }
        public virtual Branch Branch { get; set; }
        public int BranchId { get; set; }
        public int RoleId { get; set; }
        public int SapEmployeeId { get; set; }
        public bool IsActive { get; set; }
        public ICollection<UsersAppovalTemplate> UsersAppovalTemplates { get; set; }
        public ICollection<NotificationsHistory> ApproverNotifications { get; set; }
        public ICollection<NotificationsHistory> OriginatorNotifications { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}
