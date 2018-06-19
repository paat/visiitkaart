using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisiitkaartBackend.Data.Models;

namespace VisiitkaartBackend.Data
{
    public class VisiitkaartDbContext : DbContext
    {
        public VisiitkaartDbContext(DbContextOptions options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<DbUser>().HasKey(table => new
            {
                table.Email
            });

            builder.Entity<DbUserRole>().HasKey(table => new {
                table.UserEmail,
                table.RoleValue
            });
        }

        public DbSet<DbUser> Users { get; set; }
        public DbSet<DbUserRole> UserRoles { get; set; }
    }
}
