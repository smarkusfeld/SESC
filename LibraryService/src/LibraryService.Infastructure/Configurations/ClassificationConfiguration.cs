using LibraryService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Infastructure.Configurations
{
    public class ClassificationConfiguration : IEntityTypeConfiguration<Classification>
    {
        public void Configure(EntityTypeBuilder<Classification> builder)
        {
            builder.HasData(
                new Classification
                {
                    Id = 1000,
                    Name = "dewey_decimal_class",
                    Label = "Dewey Decimal Class"
                },
                new Classification
                {
                    Id = 1001,
                    Name = "lc_classifications",
                    Label = " Library of Congress"
                },
                new Classification
                {

                    Id = 1002,
                    Name = "udc",
                    Label = "Universal Decimal Classification"
                }); 
         }

    }
}
