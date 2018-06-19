using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VisiitkaartBackend.Data.Models
{
    public class DbUser
    {
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public ICollection<DbUserRole> Roles { get; set; }
    }
}
