using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using StudentService.Domain.Entities;
using System.Reflection.Emit;
using StudentService.Domain.Common.Enums;

namespace StudentService.Infastructure.Configurations
{
    /// <summary>
    /// Configuration for the <see cref="School"/> value object
    /// </summary>
    public class SchoolEntityTypeConfiguration : IEntityTypeConfiguration<School>
    {
        public void Configure(EntityTypeBuilder<School> builder)
        {
            builder
               .Property(p => p.Id)
               .ValueGeneratedOnAdd();

            builder
                .HasKey(p => p.Id);

            builder
                 .Property(x => x.Name)
                 .HasColumnType("varchar(50)")
                 .IsRequired();

            builder.HasData
            (
                new School(1, "School of Arts"),
                new School(2, "School of Build Environment, Engineering, and Computing"),
                new School(3, "School of Business"),
                new School(4, "School of Health"),
                new School(5, "School of SocialSciences"),
                new School(6, "School of Education"),
                new School(7, "School of Law"),
                new School(8, "School of Sports")
            );
        }
    }
}