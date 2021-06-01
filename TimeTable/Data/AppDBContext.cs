using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using TimeTable.Models;

namespace TimeTable.Data
{
    public class AppDBContext : IdentityDbContext<UserStudent>
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Slot> Slots { get; set; }
        public DbSet<NewPost> NewsPosts { get; set; }


        // Создание ролей через миграции
        //protected override void OnModelCreating(ModelBuilder builder )
        //{
        //    base.OnModelCreating(builder);

        //    string AdminID = Guid.NewGuid().ToString();
        //    string AdminRoleID = Guid.NewGuid().ToString();

        //    builder.Entity<IdentityUser>().HasData(new IdentityUser
        //    {
        //        Id = AdminID,
        //        UserName = "Admin",
        //        NormalizedUserName = "ADMIN",
        //        PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null,"admin"),
        //        SecurityStamp = String.Empty
        //    });

        //    builder.Entity<IdentityRole>().HasData(new IdentityRole
        //    { 
        //        Id = AdminRoleID,
        //        Name = "admin",
        //        NormalizedName = "ADMIN"
        //    });

        //    builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        //    {
        //        UserId = AdminID,
        //        RoleId = AdminRoleID
        //    });

        //    builder.Entity<IdentityRole>().HasData(new IdentityRole
        //    {
        //        Id = Guid.NewGuid().ToString(),
        //        Name = "student",
        //        NormalizedName = "STUDENT"
        //    });

        //    builder.Entity<IdentityRole>().HasData(new IdentityRole
        //    {
        //        Id = Guid.NewGuid().ToString(),
        //        Name = "teacher",
        //        NormalizedName = "TEACHER"
        //    });
        //}
    }
}
