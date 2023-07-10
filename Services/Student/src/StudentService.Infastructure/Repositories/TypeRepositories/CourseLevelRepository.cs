using StudentService.Application.Interfaces.Repositories.TypeRepositories;
using StudentService.Domain.Entities;
using StudentService.Infastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentService.Infastructure.Repositories.TypeRepositories
{
    public class CourseLevelRepository : GenericRepository<CourseLevel>, ICourseLevelRepository
    {
        public CourseLevelRepository(DataContext dbContext) : base(dbContext)
        {

        }
    }
}
