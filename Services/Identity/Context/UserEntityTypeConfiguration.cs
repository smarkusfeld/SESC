using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using IdentityService.Models;

namespace IdentityService.Context
{
    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<IdentityUser>
    {
        public void Configure(EntityTypeBuilder<IdentityUser> builder)
        {

            //seed users
            builder.HasData(
             new User
             {
                 Id = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                 FirstName = "Jane",
                 MiddleName = "A",
                 Surname = "Doe",
                 UserName = "janeadoe@email.com",
                 Email = "janeadoe@email.com",
                 EmailConfirmed = true,
                 PhoneNumberConfirmed = true
             },
             new User
             {
                 FirstName = "John",
                 MiddleName = "B",
                 Surname = "Doe",
                 UserName = "johnbdoe@email.com",
                 Email = "johnbdoe@email.com",
                 EmailConfirmed = true,
                 PhoneNumberConfirmed = true
             },
             new User
             {
                 Id = "837268b4-2b97-45fa-bd46-a4d138e77ddb",
                 FirstName = "Joe",
                 MiddleName = "C",
                 Surname = "Schmoe",
                 UserName = "superUser!",
                 Email = "admin@email.com",
                 EmailConfirmed = true,
                 PhoneNumberConfirmed = true
             }); 
        }
    }
}
