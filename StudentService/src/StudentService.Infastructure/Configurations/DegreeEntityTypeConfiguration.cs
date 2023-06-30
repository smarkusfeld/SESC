using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using StudentService.Domain.Entities;
using System.Reflection.Emit;
using StudentService.Domain.Common.Enums;

namespace StudentService.Infastructure.Configurations
{
    /// <summary>
    /// Configuration for the <see cref="Degree"/> value object
    /// </summary>
    public class DegreeEntityTypeConfiguration : IEntityTypeConfiguration<Degree>
    {
        public void Configure(EntityTypeBuilder<Degree> builder)
        {
            builder
               .Property(p => p.Id)
               .ValueGeneratedOnAdd();

            builder
                .HasKey(p => p.Id);

            builder
                 .Property(x => x.QualificationLevel)
                 .IsRequired(); 

            builder
                 .Property(x => x.Name)
                 .HasColumnType("varchar(50)")
                 .IsRequired();

            builder
                 .Property(x => x.Abbr)
                 .HasColumnType("varchar(5)")
                 .IsRequired(false);

            builder
               .Property(x => x.DegreeCategory)
               .HasConversion(s => s.ToString(), s => (DegreeCategory)Enum.Parse(typeof(DegreeCategory), s));

            // degree types to seed database
            builder.HasData
            (
                 new Degree
                 {
                     Id = 98,
                     Name = "Foundation Degree In Education",
                     Abbr = "FdA",
                     DegreeCategory = DegreeCategory.Undergraduate,
                     QualificationLevel = 5
                 },
                 new Degree
                 {
                     Id = 99,
                     Name = "Foundation Degree In Science",
                     Abbr = "FdSc",
                     DegreeCategory = DegreeCategory.Undergraduate,
                     QualificationLevel = 5
                 },
                  new Degree
                  {
                      Id = 100,
                      Name = "Bachelor of Science",
                      Abbr = "BSc",
                      DegreeCategory = DegreeCategory.Undergraduate,
                      QualificationLevel = 6
                  },
                new Degree
                {
                    Id = 100,
                    Name = "Bachelor of Science",
                    Abbr = "BSc",
                    DegreeCategory = DegreeCategory.Undergraduate,
                    QualificationLevel = 6
                },
                new Degree
                {
                    Id = 101,
                    Name = "Bachelor of Arts",
                    Abbr = "BA",
                    DegreeCategory = DegreeCategory.Undergraduate,
                    QualificationLevel = 6
                },
                new Degree
                {
                    Id = 102,
                    Name = "Bachelor of Engineering",
                    Abbr = "BEng",
                    DegreeCategory = DegreeCategory.Undergraduate,
                    QualificationLevel = 6
                },
                new Degree
                {
                    Id = 103,
                    Name = "Bachelor of Education",
                    Abbr = "BEd",
                    DegreeCategory = DegreeCategory.Undergraduate,
                    QualificationLevel = 6
                },
                new Degree
                {
                    Id = 104,
                    Name = "Bachelor of Law",
                    Abbr = "LLB",
                    DegreeCategory = DegreeCategory.Undergraduate,
                    QualificationLevel = 6
                },
                new Degree
                {
                    Id = 105,
                    Name = "Bachelor of Medicine",
                    Abbr = "MB",
                    DegreeCategory = DegreeCategory.Undergraduate,
                    QualificationLevel = 6
                },
                new Degree
                {
                    Id = 106,
                    Name = "Bachelor of Surgery",
                    Abbr = "ChB",
                    DegreeCategory = DegreeCategory.Undergraduate,
                    QualificationLevel = 6
                },
                new Degree
                {
                    Id = 106,
                    Name = "Bachelor of Surgery",
                    Abbr = "ChB",
                    DegreeCategory = DegreeCategory.Undergraduate,
                    QualificationLevel = 6
                },
                new Degree
                {
                    Id = 107,
                    Name = "Master of Philosophy",
                    Abbr = "MSc",
                    DegreeCategory = DegreeCategory.Undergraduate,
                    QualificationLevel = 7
                },
                new Degree
                {
                    Id = 108,
                    Name = "Master of Science",
                    Abbr = "MSc",
                    DegreeCategory = DegreeCategory.Undergraduate,
                    QualificationLevel = 7
                },
                new Degree
                {
                    Id = 109,
                    Name = "Master of Arts",
                    Abbr = "MA",
                    DegreeCategory = DegreeCategory.Undergraduate,
                    QualificationLevel = 7
                },
                new Degree
                {
                    Id =  110,
                    Name = "Master of Engineering",
                    Abbr = "MEng",
                    DegreeCategory = DegreeCategory.Undergraduate,
                    QualificationLevel = 7
                },
                new Degree
                {
                    Id =  111,
                    Name = "Master of Education",
                    Abbr = "MEd",
                    DegreeCategory = DegreeCategory.Undergraduate,
                    QualificationLevel = 7
                },
                new Degree
                {
                    Id =  112,
                    Name = "Master of Law",
                    Abbr = "LLM",
                    DegreeCategory = DegreeCategory.Undergraduate,
                    QualificationLevel = 7
                }


             );

        }
    }
}
