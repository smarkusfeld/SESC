using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Identity.Client;
using RegistrarService.Domain.Entities;
using RegistrarService.Infastructure.Context;
using RegistrarService.Infastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrarService.Application.Interfaces.Repositories.TypeRepositories
{
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        public CourseRepository(DataContext dbContext) : base(dbContext)
        {

        }
        
        public override async Task<Course> GetAsync(object key)
        {
            IQueryable<Course> query = _set;

            query = query.Where(x => x.CourseCode.Equals(key));

            query = query.Include("Programme");

            query = query.Include("CourseLevels");

            return await query.AsNoTracking().SingleAsync();

        }

        public async Task<IEnumerable<Course>> GetAllActiveCoursesAsync()
        {
            IQueryable<Course> query = _set;

            query = query.Where(x => x.IsActive);

            query = query.Include("Programme");

            query = query.Include("CourseLevels");

            return await query.AsNoTracking().ToListAsync();

        }


    }
}
