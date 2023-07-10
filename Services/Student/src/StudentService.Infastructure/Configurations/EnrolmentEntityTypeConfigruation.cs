using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentService.Domain.Common.Enums;
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
    /// Configuration for the <see cref="CourseRegistration"/> value object
    /// </summary>
    public class RegistrationTypeConfiguration : IEntityTypeConfiguration<CourseRegistration>
    {
        public void Configure(EntityTypeBuilder<CourseRegistration> builder)
        {
            builder
                .HasKey(x =>x.Id);

            builder
                .Property(x => x.StudentId)
                .IsRequired();

            builder
                .Property(x => x.CourseId)
                .IsRequired();

            builder
                .Property(x => x.RegistrationDate)
                .IsRequired();

           
            
        }
    }
}
