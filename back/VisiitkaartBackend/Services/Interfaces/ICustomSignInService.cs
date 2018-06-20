using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisiitkaartBackend.Data.Models;
using VisiitkaartBackend.Data.Models.Enums;

namespace VisiitkaartBackend.Services.Interfaces
{
    public interface ICustomSignInService
    {
        User RegisterNewUser(string email, string password, List<UserRoleEnum> roles);
        string GetJwtToken(string email, string password);
    }
}
