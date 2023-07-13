using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace IdentityService.DataContext
{
    public class RoleEntityTypeConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
            new IdentityRole
            {
                Id = "100",
                Name = "admin",
                NormalizedName = "ADMIN"
            },
            new IdentityRole
            {
                Id = "101",
                Name = "user",
                NormalizedName = "USER"
            },
            new IdentityRole
            {
                Id = "102",
                Name = "staff",
                NormalizedName = "STAFF"
            },
            new IdentityRole
            {
                Id = "103",
                Name = "registrar",
                NormalizedName = "REGISTRAR"
            },
            new IdentityRole
            {
                Id = "104",
                Name = "library",
                NormalizedName = "LIBRARY"
            },
            new IdentityRole
            {
                Id = "105",
                Name = "finance",
                NormalizedName = "FINANCE"
            },
            new IdentityRole
            {
                Id = "106",
                Name = "faculty",
                NormalizedName = "FACULTY"
            },
            new IdentityRole
            {
                Id = "107",
                Name = "staff",
                NormalizedName = "STAFF"
            },
            new IdentityRole
            {
                Id = "108",
                Name = "guest",
                NormalizedName = "GUEST"
            },
            new IdentityRole
            {
                Id = "109",
                Name = "student",
                NormalizedName = "STUDENT"
            });

        }
    }
}

