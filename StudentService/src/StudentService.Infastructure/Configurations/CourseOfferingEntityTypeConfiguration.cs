using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentService.Domain.Common.Enums;
using StudentService.Domain.Entities;

namespace StudentService.Infastructure.Configurations
{
    /// <summary>
    /// Configuration for the <see cref="CourseOffering"/> entity
    /// </summary>
    public class CourseOfferingEntityTypeConfiguration : IEntityTypeConfiguration<CourseOffering>
    {
        public void Configure(EntityTypeBuilder<CourseOffering> builder)
        {
            builder
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();
            builder
                .HasKey(p => p.Id);

            builder
                 .Property(x => x.CourseId)
                 .IsRequired(true);

            builder
                 .Property(x => x.QualificationId)
                 .IsRequired(true);

            builder
                 .Property(x => x.Name)
                 .HasColumnType("varchar(50)")
                 .IsRequired();

            builder
                 .Property(x => x.StartDate)
                 .IsRequired();

            builder
                 .Property(x => x.EndDate)
                 .IsRequired();

            builder
                 .Property(x => x.Credits)
                 .IsRequired(false);

        }
    }
}