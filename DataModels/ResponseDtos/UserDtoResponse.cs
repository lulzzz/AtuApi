using AtuApi.Models;
using DataModels.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels.ResponseDtos
{
    public class UserDtoResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }    
        public int BranchId { get; set; }
        public string Email { get; set; }
        public string Position { get; set; }
        public bool IsActive { get; set; }
        public int RoleId { get; set; }
        public int SapEmployeeId { get; set; }        
        public List<PermissionDto> Permissions { get; set; }
    }
}
