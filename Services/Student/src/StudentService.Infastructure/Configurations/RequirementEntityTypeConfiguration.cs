using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentService.Domain.Entities;
using StudentService.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace StudentService.Infastructure.Configurations
{
    /// <summary>
    /// Configuration for the <see cref="Requirement"/> value object
    /// </summary>
    public class RequirementEntityTypeConfiguration : IEntityTypeConfiguration<Requirement>
    {
        public void Configure(EntityTypeBuilder<Requirement> builder)
        {
            builder
                .Property(x => x.QualificationId);

            builder
               .Property(x => x.CourseOfferingId);

            builder
                .HasKey(x => new { x.QualificationId, x.CourseOfferingId });

            


        }
    }
}
