using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using StudentService.Domain.Entities;
using System.Reflection.Emit;
using StudentService.Domain.Common.Enums;

namespace StudentService.Infastructure.Configurations
{
    /// <summary>
    /// Configuration for the <see cref="Subject"/> value object
    /// </summary>
    public class SubjectEntityTypeConfiguration : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder
               .Property(p => p.Id)
               .ValueGeneratedOnAdd();

            builder
                .HasKey(p => p.Id);

            builder
                 .Property(x => x.Name)
                 .HasColumnType("varchar(50)")
                 .IsRequired();

            builder.HasData
            (
                new Subject(1, "Accounting and Finance"),
                new Subject(2, "Art and Design"),
                new Subject(3, "Architecture and Landscape Design"),
                new Subject(4, "Biomedical Sciences"),
                new Subject(5, "Business and Management"),
                new Subject(6, "Civil Engineering"),
                new Subject(7, "Computing and Engineering"),
                new Subject(8, "Creative Technologies"),
                new Subject(9, "Criminology, Psychology, and Sociology"),
                new Subject(10, "Dietetics and Nutrition"),
                new Subject(11, "Economics and Analytics"),
                new Subject(12, "Education and Teaching"),
                new Subject(13, "English Language Study"),
                new Subject(14, "Engish, History, and Media"),
                new Subject(15, "Events Management"),
                new Subject(16, "Film"),
                new Subject(17, "Geography, Planning, and Housing"),
                new Subject(18, "Law"),
                new Subject(19, "Marketing, PR, and Journalism"),
                new Subject(20, "Music and Sound"),
                new Subject(21, "Nursing, Healthcare, and Health Promotion"),
                new Subject(22, "Performing Arts"),
                new Subject(23, "Politics and International Relations"),
                new Subject(24, "Psychological Therapies and Mental Health"),
                new Subject(25, "Rehabilitation Therapies"),
                new Subject(26, "Safety and Environmental Health"),
                new Subject(27, "Social and Communication Studies"),
                new Subject(28, "Speech and Language Sciences"),
                new Subject(29, "Sport"),
                new Subject(30, "Surveying, Construction, and Project Management"),
                new Subject(31, "Tourism and Hospitality Management")

            );
        }
    }
}