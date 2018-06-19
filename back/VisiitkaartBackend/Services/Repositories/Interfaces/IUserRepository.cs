using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisiitkaartBackend.Data.Models;

namespace VisiitkaartBackend.Services.Repositories.Interfaces
{
    public interface IUserRepository
    {
        DbUser Get(string email);
        DbUser Add(DbUser user);
    }
}
