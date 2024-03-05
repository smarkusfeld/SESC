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
    /// Configuration for the <see cref="Course"/> entity
    /// </summary>
    public class CourseEntityTypeConfiguration  : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
         
            builder
                .HasKey(p => p.CourseCode);

            builder
            .Property(x => x.CourseCode)
            .IsRequired(true);


            builder
                 .Property(x => x.IsActive);


            builder
               .Property(x => x.CourseType)
               .HasConversion(s => s.ToString(), s => (CourseType)Enum.Parse(typeof(CourseType), s));


        }
    }
}
