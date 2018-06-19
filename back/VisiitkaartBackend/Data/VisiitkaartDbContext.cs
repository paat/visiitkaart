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
            builder.Entity<User>().HasKey(table => table.Email);

            builder.Entity<UserRole>()
                .HasKey(table => new
                {
                    table.UserEmail,
                    table.RoleValue
                });

            //builder.Entity<UserRole>()
            //    .HasOne(r => r.User)
            //    .WithMany()
            //    .HasForeignKey(r => r.Email)
            //    .IsRequired()
            //;

        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
    }
}
