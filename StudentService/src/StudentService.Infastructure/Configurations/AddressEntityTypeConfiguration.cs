using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentService.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentService.Infastructure.Configurations
{
    /// <summary>
    /// Configuration for the <see cref="Address"/> value object
    /// </summary>
    public class AddressEntityTypeConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder
                 .Property(x => x.LineOne)
                 .HasColumnType("varchar(100)")
                 .IsRequired();

            builder
                .Property(x => x.LineTwo)
                .HasColumnType("varchar(100)");

            builder
               .Property(x => x.LineThree)
               .HasColumnType("varchar(125)");

            builder
               .Property(x => x.Town_City)
               .HasColumnType("varchar(50)");

            builder
               .Property(x => x.County_Region)
               .HasColumnType("varchar(50)");

            builder
               .Property(x => x.PostCode)
               .HasColumnType("varchar(20)");

            builder
               .Property(x => x.Country)
               .HasColumnType("varchar(30)");

        }
    }
}
