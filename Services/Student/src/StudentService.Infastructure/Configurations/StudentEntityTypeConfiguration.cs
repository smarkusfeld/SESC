using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentService.Domain.Entities;
using StudentService.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace StudentService.Infastructure.Configurations
{
    /// <summary>
    /// Configuration for the <see cref="Student"/> entity
    /// </summary>
    public class StudentEntityTypeConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder
                .Property(p => p.AccountNumber)
                .ValueGeneratedOnAdd();
            builder
                .HasAlternateKey(p => p.AccountNumber);

            builder
                 .Property(x => x.StudentId);

            builder
                .HasKey(p => p.StudentId);
                 

            builder
                 .Property(x => x.FirstName)
                 .HasColumnType("varchar(50)")
                 .IsRequired();

            builder
                .Property(x => x.MiddleName)
                .HasColumnType("varchar(50)");

            builder
               .Property(x => x.Surname)
               .HasColumnType("varchar(50)");

            

        }
    }
}
