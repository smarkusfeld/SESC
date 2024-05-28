using Google.Protobuf.WellKnownTypes;
using Microsoft.EntityFrameworkCore;
using RegistrarService.Domain.Common.Enums;
using RegistrarService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace RegistrarService.Infastructure.Context
{
    public static class ModelBuilderExtensions
    {
        public static void SeedDatabase(this ModelBuilder builder)
        {
            builder.Entity<AcademicYear>().HasData
            (
                new AcademicYear(2022, 2023)
                {
                    Id = 1
                },
                 new AcademicYear(2023, 2024)
                 {
                     Id = 2
                 },
                 new AcademicYear(2024, 2025)
                 {
                     Id = 3
                 },
                 new AcademicYear(2025, 2026)
                 {
                     Id = 4
                 },
                 new AcademicYear(2026, 2027)
                 {
                     Id = 5
                 },
                 new AcademicYear(2027, 2028)
                 {
                     Id = 6
                 },
                 new AcademicYear(2028, 2029)
                 {
                     Id = 7
                 }
             );
            builder.Entity<AcademicTerm>().HasData
           (
               new AcademicTerm("Semester 1", 1, new DateTime(2022, 09, 18), new DateTime(2023, 01, 15))
               {
                   Id = 1,
               },
               new AcademicTerm("Semester 2", 1, new DateTime(2023, 01, 25), new DateTime(2023, 05, 24))
               {
                   Id = 2,
               }, 
               new AcademicTerm("Semester 1", 2, new DateTime(2023, 09, 18), new DateTime(2024, 01, 15))
               {
                   Id = 3,
               },
               new AcademicTerm("Semester 2", 2, new DateTime(2024, 01, 25), new DateTime(2024, 05, 24))
               {
                   Id = 4,
               },
               new AcademicTerm("Semester 1", 3, new DateTime(2024, 09, 18), new DateTime(2025, 01, 15))
               {
                   Id = 5,
               },
               new AcademicTerm("Semester 2", 3, new DateTime(2025, 01, 25), new DateTime(2025, 05, 24))
               {
                   Id = 6,
               },
               new AcademicTerm("Semester 1", 4, new DateTime(2025, 09, 18), new DateTime(2026, 01, 15))
               {
                   Id = 7,
               },
               new AcademicTerm("Semester 2", 4, new DateTime(2026, 01, 25), new DateTime(2026, 05, 24))
               {
                   Id = 8,
               }
            );
            builder.Entity<Programme>().HasData(
                new Programme
                {
                    ProgrammeCode = "8L17",
                    Name = "MEng Computer Science",
                    Duration = 3,
                    TotalCredits = 240,
                    SchoolId = 2,
                    AwardId = 110,
                    SubjectId = 7,
                }
            );
            builder.Entity<Course>().HasData(
                new Course
                {                   
                   IsActive=true,
                   CourseCode = "8L17-2022",
                   ProgrammeCode = "8L17",
                   StartDate = new DateTime(2022, 09, 01),
                   EnrolmentDeadline = new DateTime(2022, 07, 01),
                   ApplicationDeadline = new DateTime(2022, 01, 15),
                   CourseType = CourseType.FullTime
                },
                new Course
                {
                    IsActive = true,
                    CourseCode = "8L17-2023",
                    ProgrammeCode = "8L17",
                    StartDate = new DateTime(2023, 09, 01),
                    EnrolmentDeadline = new DateTime(2023, 07, 01),
                    ApplicationDeadline = new DateTime(2023, 01, 15),
                    CourseType = CourseType.FullTime
                },
                new Course
                {
                    IsActive = true,
                    CourseCode = "8L17-2024",
                    ProgrammeCode = "8L17",
                    StartDate = new DateTime(2024, 09, 01),
                    EnrolmentDeadline = new DateTime(2024, 07, 01),
                    ApplicationDeadline = new DateTime(2024, 01, 15),
                    CourseType = CourseType.FullTime
                }
            );
            builder.Entity<CourseLevel>().HasData(
               new CourseLevel
               {
                   CourseLevelId = 1,
                   CourseCode = "8L17-2022",
                   QualificationLevel = 4,
                   Credits = 60,
                   TuitionFee = 9250.00,
                   AcademicYearId = 1 
               },
               new CourseLevel
               {
                   CourseLevelId = 2,
                   CourseCode = "8L17-2022",
                   QualificationLevel = 5,
                   Credits = 60,
                   TuitionFee = 9250.00,
                   AcademicYearId = 2
               },
               new CourseLevel
               {
                   CourseLevelId = 3,
                   CourseCode = "8L17-2022",
                   QualificationLevel = 6,
                   Credits = 60,
                   TuitionFee = 9250.00,
                   AcademicYearId = 3
               },
               new CourseLevel
               {
                   CourseLevelId = 4,
                   CourseCode = "8L17-2022",
                   QualificationLevel = 7,
                   Credits = 60,
                   TuitionFee = 9250.00,
                   AcademicYearId = 4
               },
               new CourseLevel
               {
                   CourseLevelId = 5,
                   CourseCode = "8L17-2023",
                   QualificationLevel = 4,
                   Credits = 60,
                   TuitionFee = 9250.00,
                   AcademicYearId = 2
               },
               new CourseLevel
               {
                   CourseLevelId = 6,
                   CourseCode = "8L17-2023",
                   QualificationLevel = 5,
                   Credits = 60,
                   TuitionFee = 9250.00,
                   AcademicYearId = 3
               },
               new CourseLevel
               {
                   CourseLevelId = 7,
                   CourseCode = "8L17-2023",
                   QualificationLevel = 6,
                   Credits = 60,
                   TuitionFee = 9250.00,
                   AcademicYearId = 4
               },
               new CourseLevel
               {
                   CourseLevelId = 8,
                   CourseCode = "8L17-2023",
                   QualificationLevel = 7,
                   Credits = 60,
                   TuitionFee = 9250.00,
                   AcademicYearId = 5
               },
               new CourseLevel
               {
                   CourseLevelId = 9,
                   CourseCode = "8L17-2024",
                   QualificationLevel = 4,
                   Credits = 60,
                   TuitionFee = 9250.00,
                   AcademicYearId = 3
               },
               new CourseLevel
               {
                   CourseLevelId = 10,
                   CourseCode = "8L17-2024",
                   QualificationLevel = 5,
                   Credits = 60,
                   TuitionFee = 9250.00,
                   AcademicYearId = 4
               },
               new CourseLevel
               {
                   CourseLevelId = 11,
                   CourseCode = "8L17-2024",
                   QualificationLevel = 6,
                   Credits = 60,
                   TuitionFee = 9250.00,
                   AcademicYearId = 5
               },
               new CourseLevel
               {
                   CourseLevelId = 12,
                   CourseCode = "8L17-2024",
                   QualificationLevel = 7,
                   Credits = 60,
                   TuitionFee = 9250.00,
                   AcademicYearId = 6
               }
           );
        }
    }
}
