using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentService.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace StudentService.Infastructure.Configurations
{
    /// <summary>
    /// Configuration for the <see cref="Contact"/> value object
    /// </summary>
    public class ContactEntityTypeConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {

            builder
                 .Property(x=> x.StudentEmail)
                .HasColumnType("varchar(255)")
                .IsRequired();

            builder
                .Property(x => x.AlternateEmail)
                .HasColumnType("varchar(255)");

            builder
               .Property(x => x.PhoneNumber)
               .HasColumnType("varchar(15)");


        }
    }
}
