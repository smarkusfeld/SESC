using StudentService.Domain.Entities;
using StudentService.Infastructure.Context;
using StudentService.Infastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentService.Application.Interfaces.Repositories.TypeRepositories
{
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        public CourseRepository(DataContext dbContext) : base(dbContext)
        {

        }
    }
}
