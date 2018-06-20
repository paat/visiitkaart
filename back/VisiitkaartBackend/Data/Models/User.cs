using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisiitkaartBackend.Data.Models.Enums;

namespace VisiitkaartBackend.Data.Models
{
    public class User
    {
        byte _roleValue;
        List<UserRoleEnum> _roles;

        public string Email { get; set; }
        public string PasswordHash { get; set; }

        public byte RoleValue {
            get
            {
                return _roleValue;
            }
            set
            {
                foreach (int role in Enum.GetValues(typeof(UserRoleEnum)))
                {
                    if ((role & value) == role)
                    {
                        if (_roles == null)
                        {
                            _roles = new List<UserRoleEnum>();
                        }
                        _roles.Add((UserRoleEnum)role);
                    }
                        
                }
                _roleValue = value;
            }

        }

        public List<UserRoleEnum> Roles {
            get
            {
                return _roles;
            }
            set
            {
                int roleValue = 0;
                foreach (int role in value)
                {
                    roleValue = (roleValue | role);
                }
                _roleValue = (byte)roleValue;
                _roles = value;
            }

        }


    }
}
