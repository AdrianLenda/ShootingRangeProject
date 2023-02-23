using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShootingRange.Models;

namespace ShootingRange.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Instructors> Instructors { get; set; }
        public DbSet<Guns> Guns { get; set; }
        public DbSet<Reservations> Reservations { get; set; }
        public DbSet<ShootingRange.Models.Manufacturers> Manufacturers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var hasher = new PasswordHasher<UserStore>();

            string roleId = Guid.NewGuid().ToString();
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = roleId,
                    Name = "Admin",
                    NormalizedName = "Admin"
                });

            string adminId = Guid.NewGuid().ToString();
            modelBuilder.Entity<IdentityUser>().HasData(
                new IdentityUser
                {
                    Id = adminId,
                    UserName = "admin@admin",
                    NormalizedUserName = "ADMIN@ADMIN",
                    Email = "admin@admin",
                    NormalizedEmail = "ADMIN@ADMIN",
                    PasswordHash = hasher.HashPassword(null, "admin")
                }
            );

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = roleId,
                    UserId = adminId
                }
            );

            modelBuilder.Entity<IdentityUser>().HasData(
                new IdentityUser
                {
                    UserName = "user@user",
                    NormalizedUserName = "USER@USER",
                    Email = "user@user",
                    NormalizedEmail = "USER@USER",
                    PasswordHash = hasher.HashPassword(null, "user")
                }
            );

        }
    }
}