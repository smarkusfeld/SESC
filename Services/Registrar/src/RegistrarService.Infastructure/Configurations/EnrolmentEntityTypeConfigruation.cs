using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RegistrarService.Domain.Common.Enums;
using RegistrarService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace RegistrarService.Infastructure.Configurations
{
    /// <summary>
    /// Configuration for the <see cref="Registration"/> value object
    /// </summary>
    public class RegistrationTypeConfiguration : IEntityTypeConfiguration<Registration>
    {
        public void Configure(EntityTypeBuilder<Registration> builder)
        {
            builder
                .HasKey(x =>x.Id);

            builder
                .Property(x => x.StudentId)
                .IsRequired();

            builder
                .Property(x => x.SessionId)
                .IsRequired();

            builder
                .Property(x => x.RegistrationDate)
                .IsRequired();

           
            
        }
    }
}
