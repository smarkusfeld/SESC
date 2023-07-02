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
            
        }
    }
}