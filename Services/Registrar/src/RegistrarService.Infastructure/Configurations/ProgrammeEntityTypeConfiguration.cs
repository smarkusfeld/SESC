using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RegistrarService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrarService.Infastructure.Configurations
{
    public class ProgrammeEntityTypeConfiguration : IEntityTypeConfiguration<Programme>
    {
        public void Configure(EntityTypeBuilder<Programme> builder)
        {

            builder
                 .Property(x => x.ProgrammeCode);

            builder
                .HasKey(p => p.ProgrammeCode);


            builder
                 .Property(x => x.Name)
                 .HasColumnType("varchar(500)")
                 .IsRequired();


        }
    }
}
