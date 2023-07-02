using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentService.Domain.Common.Enums;
using StudentService.Domain.Entities;
using StudentService.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace StudentService.Infastructure.Configurations
{
    /// <summary>
    /// Configuration for the <see cref="Offer"/> entity
    /// </summary>
    public class OfferEntityTypeConfiguration : IEntityTypeConfiguration<Offer>
    {
        public void Configure(EntityTypeBuilder<Offer> builder)
        {
            builder
                .Property(p => p.OfferNumber)
                .ValueGeneratedOnAdd();

            builder
                .HasKey(p => p.OfferNumber);

            builder
                .Property(x => x.EnrolmentId)
                .IsRequired(false);

            builder
                .Property(x => x.CourseId)
                .IsRequired();

            builder
                 .Property(x => x.FirstName)
                 .HasColumnType("varchar(50)")
                 .IsRequired();

            builder
                .Property(x => x.MiddleName)
                .HasColumnType("varchar(50)");

            builder
               .Property(x => x.Surname)
               .HasColumnType("varchar(50)");

            builder
                .Property(x => x.Status)
                .HasConversion(s => s.ToString(), s => (OfferStatus)Enum.Parse(typeof(OfferStatus), s));
        }
    }
}
