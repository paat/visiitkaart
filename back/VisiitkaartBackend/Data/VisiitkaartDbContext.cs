using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisiitkaartBackend.Data.Models;
using VisiitkaartBackend.Data.Models.Enums;
using VisiitkaartBackend.Services;

namespace VisiitkaartBackend.Data
{
    public class VisiitkaartDbContext : DbContext
    {
        private IConfiguration _configuration;

        public VisiitkaartDbContext(DbContextOptions options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().HasKey(table => table.Email);
            builder.Entity<User>()
                .Property(b => b.PasswordHash)
                .HasMaxLength(200);
            builder.Entity<User>().Ignore(u => u.Roles);

            User adminUser = CustomSignInService.CreateUserEntity(
                _configuration["defaultUser"],
                _configuration["defaultPass"],
                new List<UserRoleEnum>() { UserRoleEnum.Admin });
            builder.Entity<User>().HasData(adminUser);
        }

        public DbSet<User> Users { get; set; }
    }
}
