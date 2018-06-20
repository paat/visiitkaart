using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisiitkaartBackend.Data.Models.Enums;

namespace VisiitkaartBackend.Data.Models
{
    public class User
    {
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        public byte RoleValue { get; set; }

        public List<UserRoleEnum> Roles
        {
            get
            {
                List<UserRoleEnum> _roles = null;
                foreach (UserRoleEnum role in Enum.GetValues(typeof(UserRoleEnum)))
                {
                    int roleCode = (int)role;
                    if ((roleCode & RoleValue) == roleCode)
                    {
                        if (_roles == null)
                        {
                            _roles = new List<UserRoleEnum>();
                        }
                        _roles.Add(role);
                    }

                }

                return _roles;
            }
            set
            {
                int roleValue = 0;
                foreach (int role in value)
                {
                    roleValue = (roleValue | role);
                }
                RoleValue = (byte)roleValue;
            }

        }


    }
}
