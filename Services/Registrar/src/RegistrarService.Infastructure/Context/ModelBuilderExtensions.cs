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
                    Id = 2022
                },
                 new AcademicYear(2023, 2024)
                 {
                     Id = 2023
                 },
                 new AcademicYear(2024, 2025)
                 {
                     Id = 2024
                 },
                 new AcademicYear(2025, 2026)
                 {
                     Id = 2025
                 },
                 new AcademicYear(2026, 2027)
                 {
                     Id = 2026
                 },
                 new AcademicYear(2027, 2028)
                 {
                     Id = 2027
                 },
                 new AcademicYear(2028, 2029)
                 {
                     Id = 2028
                 },
                 new AcademicYear(2029, 2030)
                 {
                     Id = 2029
                 },
                 new AcademicYear(2030, 2031)
                 {
                     Id = 2030
                 }
             );
            builder.Entity<AcademicTerm>().HasData
           (
               new AcademicTerm("Semester 1", 2022, new DateTime(2022, 09, 18), new DateTime(2023, 01, 15))
               {
                   Id = 1,
               },
               new AcademicTerm("Semester 2", 2022, new DateTime(2023, 01, 25), new DateTime(2023, 05, 24))
               {
                   Id = 2,
               }, 
               new AcademicTerm("Semester 1", 2023, new DateTime(2023, 09, 18), new DateTime(2024, 01, 15))
               {
                   Id = 3,
               },
               new AcademicTerm("Semester 2", 2023, new DateTime(2024, 01, 25), new DateTime(2024, 05, 24))
               {
                   Id = 4,
               },
               new AcademicTerm("Semester 1", 2024, new DateTime(2024, 09, 18), new DateTime(2025, 01, 15))
               {
                   Id = 5,
               },
               new AcademicTerm("Semester 2", 2024, new DateTime(2025, 01, 25), new DateTime(2025, 05, 24))
               {
                   Id = 6,
               },
               new AcademicTerm("Semester 1", 2025, new DateTime(2025, 09, 18), new DateTime(2026, 01, 15))
               {
                   Id = 7,
               },
               new AcademicTerm("Semester 2", 2025, new DateTime(2026, 01, 25), new DateTime(2026, 05, 24))
               {
                   Id = 8,
               },
               new AcademicTerm("Semester 1", 2026, new DateTime(2026, 09, 18), new DateTime(2027, 01, 15))
               {
                   Id = 9,
               },
               new AcademicTerm("Semester 2", 2026, new DateTime(2027, 01, 25), new DateTime(2028, 05, 24))
               {
                   Id = 10,
               },
               new AcademicTerm("Semester 1", 2027, new DateTime(2027, 09, 18), new DateTime(2028, 01, 15))
               {
                   Id = 11,
               },
               new AcademicTerm("Semester 2", 2027, new DateTime(2028, 01, 25), new DateTime(2028, 01, 15))
               {
                   Id = 12,
               },
               new AcademicTerm("Semester 1", 2028, new DateTime(2028, 09, 18), new DateTime(2029, 01, 15))
               {
                   Id = 13,
               },
               new AcademicTerm("Semester 2", 2028, new DateTime(2029, 01, 25), new DateTime(2029, 01, 15))
               {
                   Id = 14,
               },
               new AcademicTerm("Semester 1", 2029, new DateTime(2029, 09, 18), new DateTime(2030, 01, 15))
               {
                   Id = 15,
               },
               new AcademicTerm("Semester 2", 2029, new DateTime(2030, 01, 25), new DateTime(2030, 01, 15))
               {
                   Id = 16,
               },
               new AcademicTerm("Semester 1", 2030, new DateTime(2030, 09, 18), new DateTime(2031, 01, 15))
               {
                   Id = 17,
               },
               new AcademicTerm("Semester 2", 2030, new DateTime(2031, 01, 25), new DateTime(2031, 01, 15))
               {
                   Id = 18,
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
                },
                new Course
                {
                    IsActive = true,
                    CourseCode = "8L17-2025",
                    ProgrammeCode = "8L17",
                    StartDate = new DateTime(2025, 09, 01),
                    EnrolmentDeadline = new DateTime(2025, 07, 01),
                    ApplicationDeadline = new DateTime(2025, 01, 15),
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
                   AcademicYearId = 2022
               },
               new CourseLevel
               {
                   CourseLevelId = 2,
                   CourseCode = "8L17-2022",
                   QualificationLevel = 5,
                   Credits = 60,
                   TuitionFee = 9250.00,
                   AcademicYearId = 2023
               },
               new CourseLevel
               {
                   CourseLevelId = 3,
                   CourseCode = "8L17-2022",
                   QualificationLevel = 6,
                   Credits = 60,
                   TuitionFee = 9250.00,
                   AcademicYearId = 2024
               },
               new CourseLevel
               {
                   CourseLevelId = 4,
                   CourseCode = "8L17-2022",
                   QualificationLevel = 7,
                   Credits = 60,
                   TuitionFee = 9250.00,
                   AcademicYearId = 2025
               },
               new CourseLevel
               {
                   CourseLevelId = 5,
                   CourseCode = "8L17-2023",
                   QualificationLevel = 4,
                   Credits = 60,
                   TuitionFee = 9250.00,
                   AcademicYearId = 2023
               },
               new CourseLevel
               {
                   CourseLevelId = 6,
                   CourseCode = "8L17-2023",
                   QualificationLevel = 5,
                   Credits = 60,
                   TuitionFee = 9250.00,
                   AcademicYearId = 2024
               },
               new CourseLevel
               {
                   CourseLevelId = 7,
                   CourseCode = "8L17-2023",
                   QualificationLevel = 6,
                   Credits = 60,
                   TuitionFee = 9250.00,
                   AcademicYearId = 2025
               },
               new CourseLevel
               {
                   CourseLevelId = 8,
                   CourseCode = "8L17-2023",
                   QualificationLevel = 7,
                   Credits = 60,
                   TuitionFee = 9250.00,
                   AcademicYearId = 2026
               },
               new CourseLevel
               {
                   CourseLevelId = 9,
                   CourseCode = "8L17-2024",
                   QualificationLevel = 4,
                   Credits = 60,
                   TuitionFee = 9250.00,
                   AcademicYearId = 2024
               },
               new CourseLevel
               {
                   CourseLevelId = 10,
                   CourseCode = "8L17-2024",
                   QualificationLevel = 5,
                   Credits = 60,
                   TuitionFee = 9250.00,
                   AcademicYearId = 2025
               },
               new CourseLevel
               {
                   CourseLevelId = 11,
                   CourseCode = "8L17-2024",
                   QualificationLevel = 6,
                   Credits = 60,
                   TuitionFee = 9250.00,
                   AcademicYearId = 2026
               },
               new CourseLevel
               {
                   CourseLevelId = 12,
                   CourseCode = "8L17-2024",
                   QualificationLevel = 7,
                   Credits = 60,
                   TuitionFee = 9250.00,
                   AcademicYearId = 2027
               },
               new CourseLevel
               {
                   CourseLevelId = 13,
                   CourseCode = "8L17-2025",
                   QualificationLevel = 4,
                   Credits = 60,
                   TuitionFee = 9250.00,
                   AcademicYearId = 2025
               },
               new CourseLevel
               {
                   CourseLevelId = 14,
                   CourseCode = "8L17-2025",
                   QualificationLevel = 5,
                   Credits = 60,
                   TuitionFee = 9250.00,
                   AcademicYearId = 2026
               },
               new CourseLevel
               {
                   CourseLevelId = 15,
                   CourseCode = "8L17-2025",
                   QualificationLevel = 6,
                   Credits = 60,
                   TuitionFee = 9250.00,
                   AcademicYearId = 2027
               },
               new CourseLevel
               {
                   CourseLevelId = 16,
                   CourseCode = "8L17-2025",
                   QualificationLevel = 7,
                   Credits = 60,
                   TuitionFee = 9250.00,
                   AcademicYearId = 2028
               }

           );

            builder.Entity<Applicant>().HasData(
                new Applicant
                {
                    ApplicantId = 11111,
                    FirstName = "John",
                    MiddleName = "A",
                    Surname = "Doe",
                    Email = "john.a.doe@applicant.com"
                   
                },
                new Applicant
                {
                    ApplicantId = 11112,
                    FirstName = "Jane",
                    MiddleName = "A",
                    Surname = "Roe",
                    Email = "jane.a.roe@applicant.com"

                }

         ); 
            builder.Entity<Student>().HasData(
                new Student
                {
                    StudentId = 123456,
                    FirstName = "Jane",
                    MiddleName = "B",
                    Surname = "Doe",
                    Status = StudentStatus.Active,
                    StudentEmail = "jane.b.doe@student.co.uk",
                    AlternateEmail = "jane.b.doe@applicant.com",
                   
                }

         );


            builder.Entity<CourseApplication>().HasData(
                new CourseApplication (11111, "8L17-2025")
                {
                    ApplicationId = 111111,
                    Status = ApplicationStatus.Received,
                    Statement = "Fake application for testing purposes only"

                },
                new CourseApplication(11112, "8L17-2025")
                {
                    ApplicationId = 111112,
                    Status = ApplicationStatus.Offer,
                    Statement = "Fake application for testing purposes only"

                }

         );
        }
    }
}
