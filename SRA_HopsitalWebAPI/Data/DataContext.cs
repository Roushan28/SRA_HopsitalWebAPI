using System.Collections.Generic;
using SRA_HopsitalWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace SRA_HopsitalWebAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Register> Registers { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
               .Property(user => user.Role).HasDefaultValue("Admin");

            Utility.CreatePasswordHash("123456", out byte[] passwordHash, out byte[] passwordSalt);

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, PasswordHash = passwordHash, PasswordSalt = passwordSalt, Username = "User1" },
                new User { Id = 2, PasswordHash = passwordHash, PasswordSalt = passwordSalt, Username = "User2" }
            );

            modelBuilder.Entity<Register>().HasData(
                new Register
                {
                    Id = 1,
                    Name = "TestUser1",
                    IdentityNo = "Test56",
                    NoofDependent =   2,
                    AvailableDate = DateTime.Now,
                    UserId= 1
                },
                new Register
                {
                    Id = 2,
                    Name = "TestUser2",
                    IdentityNo = "BODPR56",
                    NoofDependent = 2,
                    AvailableDate = DateTime.Now,                   
                    UserId = 2
                }
            );
         
        }
    }
}