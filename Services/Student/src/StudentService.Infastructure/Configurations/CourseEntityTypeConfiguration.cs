using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentService.Domain.Common.Enums;
using StudentService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace StudentService.Infastructure.Configurations
{
    /// <summary>
    /// Configuration for the <see cref="Course"/> entity
    /// </summary>
    public class CourseEntityTypeConfiguration  : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();
            builder
                .HasKey(p => p.Id);

            builder
            .Property(x => x.CourseCode)
            .IsRequired(true);

            builder
             .Property(x => x.AwardId);

            builder
                 .Property(x => x.SchoolId)
                 .IsRequired(true);

            builder
                 .Property(x => x.Duration)
                 .IsRequired(true);

            builder
                 .Property(x => x.IsActive);

            builder
                 .Property(x => x.Name)
                 .HasColumnType("varchar(50)")
                 .IsRequired();

            builder
               .Property(x => x.CourseType)
               .HasConversion(s => s.ToString(), s => (CourseType)Enum.Parse(typeof(CourseType), s));


        }
    }
}
