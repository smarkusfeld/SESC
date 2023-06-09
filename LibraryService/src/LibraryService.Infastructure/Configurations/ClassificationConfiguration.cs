using LibraryService.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Infastructure.Configurations
{
    public class ClassificationConfiguration : IEntityTypeConfiguration<ClassificationModel>
    {
        public void Configure(EntityTypeBuilder<ClassificationModel> builder)
        {
            builder.HasData(
                new ClassificationModel
                {
                    Id = 1000,
                    Name = "dewey_decimal_class",
                    Label = "Dewey Decimal Class"
                },
                new ClassificationModel
                {
                    Id = 1001,
                    Name = "lc_classifications",
                    Label = " Library of Congress"
                },
                new ClassificationModel
                {

                    Id = 1002,
                    Name = "udc",
                    Label = "Universal Decimal Classification"
                }); 
         }

    }
}
