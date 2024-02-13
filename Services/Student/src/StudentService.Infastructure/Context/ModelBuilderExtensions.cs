using Google.Protobuf.WellKnownTypes;
using Microsoft.EntityFrameworkCore;
using StudentService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace StudentService.Infastructure.Context
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
                   Name = "Fall",
                   AcademicYearId = 1
               },
               new AcademicTerm
               {
                   Id = 2,
                   Name = "Spring",
                   AcademicYearId = 1
               },
               new AcademicTerm
               {
                   Id = 3,
                   Name = "Fall",
                   AcademicYearId = 2
               },
               new AcademicTerm
               {
                   Id = 4,
                   Name = "Spring",
                   AcademicYearId = 2
               },
                new AcademicTerm
                {
                    Id = 5,
                    Name = "Fall",
                    AcademicYearId = 3
                },
               new AcademicTerm
               {
                   Id = 6,
                   Name = "Spring",
                   AcademicYearId = 3
               }
            );

            builder.Entity<Course>().HasData(
                new Course
                {
                   Id =1,
                   IsActive=true,
                   Name = "Computer Science",
                   CourseCode = "L27",
                   Duration = 3,
                   SchoolId = 2,
                   AwardId = 100,
                   SubjectId = 7,
                }
            );
            
        }
    }
}
