using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using IdentityService.Models;
using System.Reflection.Emit;
using IdentityService.Models.ValueObjects;

namespace IdentityService.Context
{
    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.OwnsOne(x => x.Address);
            builder.OwnsOne(x=>x.TermAddress);
            //add foreign keys

            builder.HasOne(x => x.UserIdentifier)
               .WithOne(y => y.User)
               .HasForeignKey<User>(y => y.UserIdentifierId);
           
         }
    }
}
