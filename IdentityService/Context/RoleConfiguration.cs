using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace IdentityService.DataContext
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
            new IdentityRole
            {
                Name = "Admin",
                NormalizedName = "ADMIN"
            },
            new IdentityRole
            {
                Name = "User",
                NormalizedName = "USER"
            },
            new IdentityRole
            {
                Name = "Staff",
                NormalizedName = "STAFF"
            },
            new IdentityRole
            {
                Name = "Registrar",
                NormalizedName = "REGISTRAR"
            },
            new IdentityRole
            {
                Name = "Library",
                NormalizedName = "LIBRARY"
            },
            new IdentityRole
            {
                Name = "Finance",
                NormalizedName = "FINANCE"
            },
            new IdentityRole
            {
                Name = "Faculty",
                NormalizedName = "FACULTY"
            },
            new IdentityRole
            {
                Name = "Staff",
                NormalizedName = "STAFF"
            },
            new IdentityRole
            {
                Name = "Guest",
                NormalizedName = "GUEST"
            },
            new IdentityRole
            {
                Name = "Student",
                NormalizedName = "STUDENT"
            });

        }
    }
}

