using AtuApi.Interfaces;
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
        public virtual Role Roles { get; set; }
        public virtual Branch Branches { get; set; }
        public int BranchesId { get; set; }
        public int RoleId { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}
