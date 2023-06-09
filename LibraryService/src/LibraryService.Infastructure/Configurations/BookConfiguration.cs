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
    public class BookConfiguration : IEntityTypeConfiguration<BookModel>
    {
        public void Configure(EntityTypeBuilder<BookModel> builder)
        {
            throw new NotImplementedException();
        }
    }
}
