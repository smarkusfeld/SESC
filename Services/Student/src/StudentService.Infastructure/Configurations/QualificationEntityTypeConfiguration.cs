using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using StudentService.Domain.Entities;
using System.Reflection.Emit;
using StudentService.Domain.Common.Enums;

namespace StudentService.Infastructure.Configurations
{
    /// <summary>
    /// Configuration for the <see cref="Qualification"/> value object
    /// </summary>
    public class QualificationEntityTypeConfiguration : IEntityTypeConfiguration<Qualification>
    {
        public void Configure(EntityTypeBuilder<Qualification> builder)
        {
            builder
               .Property(p => p.Id)
               .ValueGeneratedOnAdd();

            builder
                .HasKey(p => p.Id);

            builder
                 .Property(x => x.Title)
                 .HasColumnType("varchar(50)")
                 .IsRequired();


            builder
               .Property(x => x.QualificationId)
               .IsRequired();

        }
    }
}

