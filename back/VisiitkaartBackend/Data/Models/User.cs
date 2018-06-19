using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VisiitkaartBackend.Data.Models
{
    public class User
    {
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public ICollection<UserRole> Roles { get; set; }
    }
}
