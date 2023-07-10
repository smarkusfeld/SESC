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
            builder.Entity<CourseLevel>().HasData(
               new CourseLevel
               {
                   Id = 2,
                   Name = "Computer Science Level 4",
                   QualificationLevel = 4,
                   CourseId = 1,
                   Credits = 120,
                   TuitionFee = 9250,
                   
               },
               new CourseLevel
               {
                   Id = 3,
                   Name = "Computer Science Level 5",
                   QualificationLevel = 5,
                   CourseId = 1,
                   Credits = 120,
                   TuitionFee = 9250,
               },
               new CourseLevel
               {
                   Id = 4,
                   Name = "Computer Science Level 6",
                   QualificationLevel = 6,
                   CourseId = 1,
                   Credits = 120,
                   TuitionFee = 9250,
               }
           );
        }
    }
}
