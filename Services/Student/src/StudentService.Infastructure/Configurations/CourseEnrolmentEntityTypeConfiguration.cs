using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using StudentService.Domain.Entities;
using System.Reflection.Emit;
using StudentService.Domain.Common.Enums;

namespace StudentService.Infastructure.Configurations
{
    /// <summary>
    /// Configuration for the <see cref="EnrolmentEntity"/> value object
    /// </summary>
    public class CourseEnrolmentEntityTypeConfiguration : IEntityTypeConfiguration<Enrolment>
    {
        public void Configure(EntityTypeBuilder<Enrolment> builder)
        {
            builder
               .Property(p => p.Id)
               .ValueGeneratedOnAdd();

            builder
                .HasKey(p => p.Id);

            builder
                 .Property(x => x.EnrolDate)
                 .IsRequired();

            builder
               .Property(x => x.CourseOfferingId)
               .IsRequired();

             builder
                 .Property(x => x.StudentId)
                 .IsRequired();

            

        }
    }
}

