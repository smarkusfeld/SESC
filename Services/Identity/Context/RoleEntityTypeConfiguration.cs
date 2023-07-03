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
                Id = "b7ea553b-141d-4b5a-bdc8-1f18bdaf4abe",
                Name = "admin",
                NormalizedName = "ADMIN"
            },
            new IdentityRole
            {
                Name = "user",
                NormalizedName = "USER"
            },
            new IdentityRole
            {
                Name = "staff",
                NormalizedName = "STAFF"
            },
            new IdentityRole
            {
               
                Name = "registrar",
                NormalizedName = "REGISTRAR"
            },
            new IdentityRole
            {
             
                Name = "library",
                NormalizedName = "LIBRARY"
            },
            new IdentityRole
            {
           
                Name = "finance",
                NormalizedName = "FINANCE"
            },
            new IdentityRole
            {
            
                Name = "faculty",
                NormalizedName = "FACULTY"
            },
            new IdentityRole
            {
              
                Name = "staff",
                NormalizedName = "STAFF"
            },
            new IdentityRole
            {
              
                Name = "guest",
                NormalizedName = "GUEST"
            },
            new IdentityRole
            {
                
                Name = "student",
                NormalizedName = "STUDENT"
            });

        }
    }
}

