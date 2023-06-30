using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using StudentService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;
using StudentService.Domain.Common.Enums;

namespace StudentService.Infastructure.Configurations
{
    /// <summary>
    /// Configuration for the <see cref="CourseResult"/> entity
    /// </summary>
   public class CourseResultEntityTypeConfiguration : IEntityTypeConfiguration<CourseResult>
    {
        public void Configure(EntityTypeBuilder<CourseResult> builder)
        {
            builder
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();
            builder
                .HasKey(p => p.Id);

            builder
                 .Property(x => x.CourseOfferingId)
                 .IsRequired(true);

            builder
                 .Property(x => x.QualificationId)
                 .IsRequired(false);

            builder
                 .Property(x => x.CourseTitle)
                 .HasColumnType("varchar(50)")
                 .IsRequired();

            builder
                 .Property(x => x.ProgressNotes)
                 .HasColumnType("varchar(450)")
                 .IsRequired(false);

            builder
                 .Property(x => x.ProgressDate)
                 .IsRequired(false);

            builder
                .Property(x => x.ProgressDecision)
                .HasConversion(s => s.ToString(), s => (ProgressDecision)Enum.Parse(typeof(ProgressDecision), s));
        }
    }
}