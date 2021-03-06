﻿using AtuApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtuApi.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int BranchId { get; set; }
        public string Email { get; set; }
        public string Position { get; set; }
        public int RoleId { get; set; }
        public int ApprovalTemplateCode { get; set; }

    }
}
