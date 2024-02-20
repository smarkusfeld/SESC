using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RegistrarService.Domain.Entities;
using System.Reflection.Emit;
using RegistrarService.Domain.Common.Enums;

namespace RegistrarService.Infastructure.Configurations
{
    /// <summary>
    /// Configuration for the <see cref="Transcript"/> value object
    /// </summary>
    public class TranscriptEntityTypeConfiguration : IEntityTypeConfiguration<Transcript>
    {
        public void Configure(EntityTypeBuilder<Transcript> builder)
        {
            builder
               .Property(p => p.Id)
               .ValueGeneratedOnAdd();

            builder
                .HasKey(p => p.Id);

            builder
                 .Property(x => x.CourseName)
                 .HasColumnType("varchar(50)")
                 .IsRequired();

            builder
                 .Property(x => x.StudentId);
            builder
                 .Property(x => x.CourseId);
        }
    }
}