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
    /// Configuration for the <see cref="Application"/> entity
    /// </summary>
    public class CourseApplicationEntityTypeConfiguration : IEntityTypeConfiguration<CourseApplication>
    {


        public void Configure(EntityTypeBuilder<CourseApplication> builder)
        {

            builder
                 .Property(x => x.ApplicationId);

            builder
                .HasKey(p => p.ApplicationId);

            builder
                .Property(p => p.Status)
               .HasConversion(s => s.ToString(), s => (ApplicationStatus)Enum.Parse(typeof(ApplicationStatus), s));





        }
    }
}
