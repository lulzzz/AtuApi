 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataModels.Dtos
{
    public class RoleDto
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public virtual ICollection<PermissionDto> Permissions { get; set; }
    }
}
