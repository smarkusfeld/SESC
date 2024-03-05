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
                new AcademicYear
                {
                    Id = 1,
                    StartYear = 2022,
                    EndYear = 2023
                },
                 new AcademicYear
                 {
                     Id = 2,
                     StartYear = 2023,
                     EndYear = 2024
                 },
                 new AcademicYear
                 {
                     Id = 3,
                     StartYear = 2024,
                     EndYear = 2025
                 }
             );
            builder.Entity<AcademicTerm>().HasData
           (
               new AcademicTerm
               {
                   Id = 1,
                   Term = "Fall"
               },
               new AcademicTerm
               {
                   Id = 2,
                   Term = "Spring"
               },
               new AcademicTerm
               {
                   Id = 3,
                   Term = "Winter"
               },
               new AcademicTerm
               {
                   Id = 4,
                   Term = "Summer"
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
                    AwardId = 100,
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
            
        }
    }
}
