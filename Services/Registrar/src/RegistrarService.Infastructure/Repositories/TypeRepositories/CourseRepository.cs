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
using System.Linq.Expressions;
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

            return await _set
                .Include(x => x.CourseLevels)
                .Include(x => x.Programme)
                .Include(x => x.Programme.School)
                .Include(x => x.Programme.Award)
                .Include(x => x.Programme.Subject)
                .AsNoTracking()
                .SingleAsync(x => x.CourseCode.Equals(key));

        }
        


        public override async Task<IEnumerable<Course>> GetAllAsync()
        {

            return await _set
               .Include(x => x.Programme)
               .Include(x => x.CourseLevels)
                .Include(x => x.Programme.School)
                .Include(x => x.Programme.Award)
                .Include(x => x.Programme.Subject)
               .AsNoTracking()
               .ToListAsync();

        }

        public override async Task<Course>GetByAsync(Expression<Func<Course, bool>> predicate)
        {

            return await _set
               .Include(x => x.Programme)
               .Include(x => x.CourseLevels)
                .Include(x => x.Programme.School)
                .Include(x => x.Programme.Award)
                .Include(x => x.Programme.Subject)
               .AsNoTracking()
               .SingleAsync(predicate);

        }

        public override async Task<IEnumerable<Course>> GetAllWhereAsync(Expression<Func<Course, bool>> predicate)
        {

            return await _set
               .Where(predicate)
               .Include(x => x.Programme)
               .Include(x => x.CourseLevels)
               .Include(x => x.Programme.School)
                .Include(x => x.Programme.Award)
                .Include(x => x.Programme.Subject)
               .AsNoTracking()
               .ToListAsync();

        }

        public async Task<IEnumerable<Course>> GetAllActiveCoursesAsync()
        {         
            return await _set
               .Where(x => x.IsActive)
               .Include(x => x.Programme)
               .Include(x => x.CourseLevels)
               .Include(x => x.Programme.School)
                .Include(x => x.Programme.Award)
                .Include(x => x.Programme.Subject)
               .AsNoTracking()
               .ToListAsync();
        }


    }
}
