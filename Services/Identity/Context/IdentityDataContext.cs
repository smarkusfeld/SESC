using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System.Reflection;
using IdentityService.Models;
using Microsoft.Identity.Client;
using System.Security.Principal;

namespace IdentityService.DataContext
{
    public class IdentityDataContext : IdentityDbContext<User>
    {
        public IdentityDataContext(DbContextOptions<IdentityDataContext> options) : base(options)
        {
            
        }
       
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //create identity server
            base.OnModelCreating(builder);
            builder.HasDefaultSchema("Identity");
            builder.Entity<User>(entity =>
            {
                entity.ToTable(name: "User");
            });
            builder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable(name: "Role");
            });
            builder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable("UserRoles");
            });
            builder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable("UserClaims");
            });
            builder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable("UserLogins");
            });
            builder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.ToTable("RoleClaims");
            });
            builder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable("UserTokens");
            });
            //apply all types in the assembly that implment IEntityTypeConfiguration 
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            //a hasher to hash the password before seeding the user to the db
            var hasher = new PasswordHasher<User>();

            //Seeding the User to AspNetUsers table
            builder.Entity<User>().HasData(
                new IdentityUser
                {
                    Id = "8e445865-a24d-4543-a6c6-9443d048cdb9", // primary key
                    UserName = "superUser!",
                    NormalizedUserName = "SUPERUSER!",
                    PasswordHash = hasher.HashPassword(null, "Pa$$w0rd")
                }
            );

            //add user to role
            builder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
            {
                RoleId = "b7ea553b-141d-4b5a-bdc8-1f18bdaf4abe",
                UserId = "8e445865-a24d-4543-a6c6-9443d048cdb9"
            });

        }
    }
}