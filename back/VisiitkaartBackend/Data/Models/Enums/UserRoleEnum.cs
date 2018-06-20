using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VisiitkaartBackend.Data.Models.Enums
{
    public enum UserRoleEnum: byte
    {
        StandardUser = 0x04, // 100
        PrepressShop = 0x20, // 100000
        Admin = 0x80         // 10000000

    }
}
