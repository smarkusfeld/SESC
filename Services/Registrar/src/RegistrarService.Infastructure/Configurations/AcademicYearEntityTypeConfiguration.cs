using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RegistrarService.Domain.Entities;
using System.Reflection.Emit;
using RegistrarService.Domain.Common.Enums;

namespace RegistrarService.Infastructure.Configurations
{
    /// <summary>
    /// Configuration for the <see cref="AcademicYear"/> value object
    /// </summary>
    public class AcademicYearEntityTypeConfiguration : IEntityTypeConfiguration<AcademicYear>
    {
        public void Configure(EntityTypeBuilder<AcademicYear> builder)
        {
            builder
               .Property(p => p.Id)
               .ValueGeneratedOnAdd();

            builder
                .HasKey(p => p.Id);

           
            

        }
    }
}
