using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentService.Domain.Common.Enums;
using StudentService.Domain.Entities;

namespace StudentService.Infastructure.Configurations
{
    /// <summary>
    /// Configuration for the <see cref="CourseLevel"/> entity
    /// </summary>
    public class CourseLevelEntityTypeConfiguration : IEntityTypeConfiguration<CourseLevel>
    {
        public void Configure(EntityTypeBuilder<CourseLevel> builder)
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
                 .Property(x => x.QualificationLevel)
                 .IsRequired(true);

            builder
                 .Property(x => x.Name)
                 .HasColumnType("varchar(50)")
                 .IsRequired();

            //builder
                 //.Property(x => x.StartDate)
                 //.IsRequired();

            //builder
                 //.Property(x => x.EndDate)
                 //.IsRequired();

            builder
                 .Property(x => x.Credits);

            builder
                 .Property(x => x.TuitionFee)
                 .HasColumnType("decimal(5, 2)")
                 .IsRequired();

        }
    }
}