using Album_Web.Entities;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Album_Web
{
    public class AppDbContext : IdentityDbContext<UserEntity>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //builder.Entity<UserEntity>().HasKey(u => u.UserName);
            //builder.Entity<UserEntity>().HasKey(u => u.Email);
            builder.Entity<UserEntity>().HasIndex(u => u.UserName).IsUnique();
            builder.Entity<UserEntity>().HasIndex(u => u.Email).IsUnique();
        }
    }
}