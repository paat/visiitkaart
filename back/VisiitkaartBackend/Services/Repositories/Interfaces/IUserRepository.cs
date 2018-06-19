using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisiitkaartBackend.Data.Models;

namespace VisiitkaartBackend.Services.Repositories.Interfaces
{
    public interface IUserRepository
    {
        User Get(string email);
        User Add(User user);
    }
}
