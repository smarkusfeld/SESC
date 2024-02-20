using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RegistrarService.Domain.Entities;
using System.Reflection.Emit;
using RegistrarService.Domain.Common.Enums;

namespace RegistrarService.Infastructure.Configurations
{
    /// <summary>
    /// Configuration for the <see cref="AcademicTerm"/> value object
    /// </summary>
    public class AcademicTermEntityTypeConfiguration : IEntityTypeConfiguration<AcademicTerm>
    {
        public void Configure(EntityTypeBuilder<AcademicTerm> builder)
        {
            builder
               .Property(p => p.Id)
               .ValueGeneratedOnAdd();

            builder
                .HasKey(p => p.Id);


            // degree types to seed database
            builder.HasData
            (
                new AcademicYear
                {
                   
                    StartYear = 2022,
                    EndYear = 2023
                },
                 new AcademicYear
                 {
                     StartYear = 2023,
                     EndYear = 2024
                 },
                 new AcademicYear
                 {
                     StartYear = 2024,
                     EndYear = 2025
                 });

        }
    }
}
