using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RegistrarService.Domain.Entities;
using System.Reflection.Emit;
using RegistrarService.Domain.Common.Enums;

namespace RegistrarService.Infastructure.Configurations
{
    /// <summary>
    /// Configuration for the <see cref="Award"/> value object
    /// </summary>
    public class AwardEntityTypeConfiguration : IEntityTypeConfiguration<Award>
    {
        public void Configure(EntityTypeBuilder<Award> builder)
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

            builder
               .Property(x => x.QualificationType)
               .HasConversion(s => s.ToString(), s => (QualificationType)Enum.Parse(typeof(QualificationType), s));
            // degree types to seed database
            builder.HasData
            (
                new Award
                {
                    Id = 91,
                    Name = "Certificate of Higher Education in Science",
                    Abbr = "HNCSc",
                    QualificationType = QualificationType.Certificate,
                    QualificationLevel = 5
                },
                 new Award
                 {
                     Id = 92,
                     Name = "Higher National Certificate in Science",
                     Abbr = "HNCSc",
                     QualificationType = QualificationType.Certificate,
                     QualificationLevel = 4
                 },
                 new Award
                 {
                     Id = 93,
                     Name = "Level 4 Award in Science",
                     Abbr = "awardSc",
                     QualificationType = QualificationType.Award,
                     QualificationLevel = 4
                 },
                 new Award
                 {
                     Id = 94,
                     Name = "Level 4 Certificate in Science",
                     Abbr = "Lvl4Sc",
                     QualificationType = QualificationType.Certificate,
                     QualificationLevel = 4
                 },
                new Award
                {
                    Id = 95,
                    Name = "Certificate of Higher Education in Science",
                    Abbr = "CertHEdSc",
                    DegreeCategory = DegreeCategory.Undergraduate,
                    QualificationType = QualificationType.Certificate,
                    QualificationLevel = 5
                },

                 new Award
                 {
                     Id = 96,
                     Name = "Foundation Degree In Education",
                     Abbr = "FdA",
                     DegreeCategory = DegreeCategory.Undergraduate,
                     QualificationType = QualificationType.Degree,
                     QualificationLevel = 5
                 },
                 new Award
                 {
                     Id = 97,
                     Name = "Foundation Degree In Science",
                     Abbr = "FdSc",
                     DegreeCategory = DegreeCategory.Undergraduate,
                     QualificationType = QualificationType.Degree,
                     QualificationLevel = 5
                 },
                  new Award
                  {
                      Id = 98,
                      Name = "Bachelor of Science",
                      Abbr = "BSc",
                      DegreeCategory = DegreeCategory.Undergraduate,
                      QualificationType = QualificationType.Degree,
                      QualificationLevel = 6
                  },
                new Award
                {
                    Id = 99,
                    Name = "Bachelor of Science",
                    Abbr = "BSc",
                    DegreeCategory = DegreeCategory.Undergraduate,
                    QualificationType = QualificationType.Degree,
                    QualificationLevel = 6
                },
                new Award
                {
                    Id = 101,
                    Name = "Bachelor of Arts",
                    Abbr = "BA",
                    DegreeCategory = DegreeCategory.Undergraduate,
                    QualificationType = QualificationType.Degree,
                    QualificationLevel = 6
                },
                new Award
                {
                    Id = 102,
                    Name = "Bachelor of Engineering",
                    Abbr = "BEng",
                    DegreeCategory = DegreeCategory.Undergraduate,
                    QualificationType = QualificationType.Degree,
                    QualificationLevel = 6
                },
                new Award
                {
                    Id = 103,
                    Name = "Bachelor of Education",
                    Abbr = "BEd",
                    DegreeCategory = DegreeCategory.Undergraduate,
                    QualificationType = QualificationType.Degree,
                    QualificationLevel = 6
                },
                new Award
                {
                    Id = 104,
                    Name = "Bachelor of Law",
                    Abbr = "LLB",
                    DegreeCategory = DegreeCategory.Undergraduate,
                    QualificationType = QualificationType.Degree,
                    QualificationLevel = 6
                },
                new Award
                {
                    Id = 105,
                    Name = "Bachelor of Medicine",
                    Abbr = "MB",
                    DegreeCategory = DegreeCategory.Undergraduate,
                    QualificationType = QualificationType.Degree,
                    QualificationLevel = 6
                },
                new Award
                {
                    Id = 106,
                    Name = "Bachelor of Surgery",
                    Abbr = "ChB",
                    DegreeCategory = DegreeCategory.Undergraduate,
                    QualificationType = QualificationType.Degree,
                    QualificationLevel = 6
                },
                new Award
                {
                    Id = 107,
                    Name = "Master of Philosophy",
                    Abbr = "MSc",
                    DegreeCategory = DegreeCategory.Undergraduate,
                    QualificationType = QualificationType.Degree,
                    QualificationLevel = 7
                },
                new Award
                {
                    Id = 108,
                    Name = "Master of Science",
                    Abbr = "MSc",
                    DegreeCategory = DegreeCategory.Undergraduate,
                    QualificationType = QualificationType.Degree,
                    QualificationLevel = 7
                },
                new Award
                {
                    Id = 109,
                    Name = "Master of Arts",
                    Abbr = "MA",
                    DegreeCategory = DegreeCategory.Undergraduate,
                    QualificationType = QualificationType.Degree,
                    QualificationLevel = 7
                },
                new Award
                {
                    Id =  110,
                    Name = "Master of Engineering",
                    Abbr = "MEng",
                    DegreeCategory = DegreeCategory.Undergraduate,
                    QualificationType = QualificationType.Degree,
                    QualificationLevel = 7
                },
                new Award
                {
                    Id =  111,
                    Name = "Master of Education",
                    Abbr = "MEd",
                    DegreeCategory = DegreeCategory.Undergraduate,
                    QualificationType = QualificationType.Degree,
                    QualificationLevel = 7
                },
                new Award
                {
                    Id =  112,
                    Name = "Master of Law",
                    Abbr = "LLM",
                    DegreeCategory = DegreeCategory.Undergraduate,
                    QualificationType = QualificationType.Degree,
                    QualificationLevel = 7
                }


             );

        }
    }
}
