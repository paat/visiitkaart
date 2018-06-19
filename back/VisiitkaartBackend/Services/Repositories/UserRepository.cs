using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisiitkaartBackend.Data;
using VisiitkaartBackend.Data.Models;
using VisiitkaartBackend.Services.Repositories.Interfaces;

namespace VisiitkaartBackend.Services.Repositories
{
    public class UserRepository : IUserRepository
    {
        private VisiitkaartDbContext _context;

        public UserRepository(VisiitkaartDbContext context)
        {
            _context = context;
        }

        public User Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public User Get(string email)
        { 
            return _context.Users.FirstOrDefault(u => u.Email == email);
        }
    }
}
