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
    /// Configuration for the <see cref="Account"/> entity
    /// </summary>
    public class StudentEntityTypeConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
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
                 

          
            

        }
    }
}
