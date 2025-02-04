using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RegistrarService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;
using RegistrarService.Domain.Common.Enums;
using RegistrarService.Domain.Common.Enums.StudentService.Domain.Common.Enums;

namespace RegistrarService.Infastructure.Configurations
{
    /// <summary>
    /// Configuration for the <see cref="ProgressionResult"/> entity
    /// </summary>
   public class ProgressionResultEntityTypeConfiguration : IEntityTypeConfiguration<ProgressionResult>
    {
        public void Configure(EntityTypeBuilder<ProgressionResult> builder)
        {
            builder
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();
            builder
                .HasKey(p => p.Id);

            builder
                 .Property(x => x.StudentId);

            //builder
                 //.Property(x => x.CourseLevelName)
                 //.HasColumnType("varchar(100)")
                 //.IsRequired();

            builder
                 .Property(x => x.ProgressNotes)
                 .HasColumnType("varchar(450)")
                 .IsRequired(false);

            builder
                 .Property(x => x.ProgressDate);

            builder
                .Property(x => x.ProgressDecision)
                .HasConversion(s => s.ToString(), s => (ProgressDecision)Enum.Parse(typeof(ProgressDecision), s));
        }
    }
}