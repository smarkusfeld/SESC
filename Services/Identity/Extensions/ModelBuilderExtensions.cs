using IdentityService.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace IdentityService.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class ModelBuilderExtensions
    {
        /// <summary>
        /// Seed related data into the database 
        /// </summary>
        /// <param name="modelBuilder"></param>
        public static void Seed(this ModelBuilder modelBuilder)
        {
            //a hasher to hash the password before seeding the user to the db
            var hasher = new PasswordHasher<User>();

            //create Ids for users
            modelBuilder.Entity<UserIdentifer>().HasData(
                new UserIdentifer('c') { UserNumber = 1123456 },
                new UserIdentifer('c') { UserNumber = 1123457 },
                new UserIdentifer('c') { UserNumber = 1123458 },
                new UserIdentifer('c') { UserNumber = 1123459 },
                new UserIdentifer('c') { UserNumber = 1123460 },
                new UserIdentifer('a') { UserNumber = 111000 },
                new UserIdentifer('a') { UserNumber = 112000 },
                new UserIdentifer('a') { UserNumber = 113000 }
            );
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = "student-seed-1",
                    UserIdentifierId = 1123456,
                    FirstName = "Jane",
                    MiddleName = "A",
                    Surname = "Doe",
                    UserName = "janeadoe@email.com",
                    Email = "janeadoe@email.com",
                    SchoolEmail = "jane.doe@student.edu",
                    PasswordHash = hasher.HashPassword(null, "Pa$$w0rd"),
                    PhoneNumber = "1234567890",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true

                },
                 new User
                 {
                     Id = "student-seed-2",
                     UserIdentifierId = 1123457,
                     FirstName = "John",
                     MiddleName = "B",
                     Surname = "Doe",
                     UserName = "johnbdoe@email.com",
                     Email = "johnbdoe@email.com",
                     SchoolEmail = "john.doe@student.edu",
                     PasswordHash = hasher.HashPassword(null, "Pa$$w0rd"),
                     PhoneNumber = "1234567890",
                     EmailConfirmed = true,
                     PhoneNumberConfirmed = true
                 },
                 new User
                 {
                     Id = "admin-seed-1",
                     UserIdentifierId = 111000,
                     UserName = "superUser!",
                     NormalizedUserName = "SUPERUSER!",
                     PasswordHash = hasher.HashPassword(null, "Pa$$w0rd")

                 });
            //add test users to role to role
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "100", //admin role id
                    UserId = "admin-seed-1"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "109", //student
                    UserId = "student-seed-1"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "109", //student
                    UserId = "student-seed-2"
                });
        }
    }
}