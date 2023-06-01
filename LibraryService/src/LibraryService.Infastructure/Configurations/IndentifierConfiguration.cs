using LibraryService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MySql.EntityFrameworkCore.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Infastructure.Configurations
{
    public class IndentifierConfiguration : IEntityTypeConfiguration<Identifier>
    {
        public void Configure(EntityTypeBuilder<Identifier> builder)
        {
            builder.HasData(
                new Identifier
                {
                    Id=1001,
                    Name = "amazon",
                    Label = "Amazon"
                },
                new Identifier
                {
                    Id = 1002,
                    Name = "google",
                     Label = "Goolge"
                },
                new Identifier
                {
                    Id = 1003,
                    Name = "librarything",
                    Label = "Library Thing"
                },
                new Identifier
                {
                    Id = 1004,
                    Name = "goodreads",
                    Label = "Goodreads"
                },
                new Identifier
                {

                    Id = 1005,
                    Name = "isbn_10",
                    Label = "ISBN 10"
                },
                new Identifier
                {
                    Id = 1006,
                    Name = "isbn_13",
                    Label = "ISBN 13"
                },
                new Identifier
                {
                    Id = 1007,
                    Name = "issn",
                    Label = "ISSN"
                },
                new Identifier
                {

                    Id = 1008,
                    Name = "lccn",
                    Label = "LCCN"
                },
                new Identifier
                {
                    Id = 1009,
                    Name = "oclc",
                    Label = "OCLC/WorldCat"
                },
                new Identifier
                {
                    Id = 1010,
                    Name = "british_library",
                    Label = "British Library"
                },
                new Identifier
                {

                    Id = 1011,
                    Name = "openlibrary",
                    Label = "OpenLibrary"
                },
                 new Identifier
                 {
                     Id = 1012,
                     Name = " British National Bibliography",
                     Label = "british_national_bibliography"
                 }
            );

        }
    }
}
