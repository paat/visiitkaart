using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisiitkaartBackend.Data.Models.Enums;

namespace VisiitkaartBackend.Data.Models
{
    public class UserRole
    {
        public string UserEmail { get; set; }
        public UserRoleEnum RoleValue { get; set; }
        public User User { get; set; }
    }
}
