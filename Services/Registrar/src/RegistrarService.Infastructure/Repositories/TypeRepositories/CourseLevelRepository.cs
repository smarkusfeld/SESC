using Microsoft.EntityFrameworkCore;
using RegistrarService.Application.Interfaces.Repositories.TypeRepositories;
using RegistrarService.Domain.Entities;
using RegistrarService.Infastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrarService.Infastructure.Repositories.TypeRepositories
{
    public class CourseLevelRepository : GenericRepository<CourseLevel>, ICourseLevelRepository
    {
        public CourseLevelRepository(DataContext dbContext) : base(dbContext)
        {

        }
        public override async Task<CourseLevel?> GetAsync(object key)
        {
            return await _set
                .SingleOrDefaultAsync(x => x.CourseLevelId.Equals(key));
        }
        public async Task<CourseLevel?> GetFirstCourseLevel(string courseCode)
        {
            return await _set
                .Where(x => x.CourseCode == courseCode)
                .OrderBy(x => x.QualificationLevel)
                .FirstOrDefaultAsync();
        }
    }
}
