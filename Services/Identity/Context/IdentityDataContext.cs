using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using IdentityService.Models;
using IdentityService.Extensions;

namespace IdentityService.DataContext
{
    /// <summary>
    /// Data Context for Identity Service. Implements <seealso cref="IdentityDbContext{TUser}"/> where 
    /// <see cref="TUser"/> is <seealso cref="User"/>
    /// </summary>
    public class IdentityDataContext : IdentityDbContext<User>
    {
        /// <summary>
        ///  Initilizes a new istance of <seealso cref="IdentityDataContext"/> 
        /// </summary>
        /// <param name="options"></param>
        public IdentityDataContext(DbContextOptions<IdentityDataContext> options) : base(options)
        {
            
        }
        DbSet<UserIdentifer> StudentIdentifiers { get; set; }

        /// <summary>
        /// Override Method to save changes async
        /// </summary>
        /// <returns></returns>
        public override int SaveChanges()
        {
            return SaveChangesAsync().GetAwaiter().GetResult();
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //create identity server
            base.OnModelCreating(builder);
            builder.HasDefaultSchema("Identity");
            // fix table names
            builder.Entity<User>(entity =>
            {
                entity.ToTable(name: "user");
            });
            builder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable(name: "role");
            });
            builder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable("user_role");
            });
            builder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable("user_role");
            });
            builder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable("user_login");
            });
            builder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.ToTable("role_claim");
            });
            builder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable("user_token");
            });
            builder.Entity<UserIdentifer>(entity =>
            { 
                entity.ToTable("user_identifier");
            });

            //apply all types in the assembly that implment IEntityTypeConfiguration 
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            //seed database
            builder.Seed();
        }
    }
}