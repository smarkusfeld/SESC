using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RegistrarService.Domain.Common.Enums;
using RegistrarService.Domain.Entities;

namespace RegistrarService.Infastructure.Configurations
{
    /// <summary>
    /// Configuration for the <see cref="Session"/> entity
    /// </summary>
    public class CourseLevelEntityTypeConfiguration : IEntityTypeConfiguration<CourseLevel>
    {
        public void Configure(EntityTypeBuilder<CourseLevel> builder)
        {
            builder
                .Property(p => p.CourseLevelId)
                .ValueGeneratedOnAdd();
            builder
                .HasKey(p => p.CourseLevelId);

            builder
                 .Property(x => x.CourseCode)
                 .IsRequired(true);

            builder
                 .Property(x => x.QualificationLevel)
                 .IsRequired(true);

            builder
                 .Property(x => x.Name)
                 .HasColumnType("varchar(50)")
                 .IsRequired();

            builder
                 .Property(x => x.Credits);

            builder
                 .Property(x => x.TuitionFee)
                 .HasColumnType("decimal(5, 2)")
                 .IsRequired();

        }
    }
}