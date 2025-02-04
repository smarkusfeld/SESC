using Microsoft.EntityFrameworkCore;
using RegistrarService.Application.Interfaces.Repositories.TypeRepositories;
using RegistrarService.Domain.Entities;
using RegistrarService.Infastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RegistrarService.Infastructure.Repositories.TypeRepositories
{
     public class CourseApplicationRepository : GenericRepository<CourseApplication>, ICourseApplicationRepository
    {
        public CourseApplicationRepository(DataContext dbContext) : base(dbContext)
        {

        }

        public override async Task<CourseApplication?> GetAsync(object key)
        {

            return await _set
                .Include(x => x.Applicant)
                .Include(x => x.Course)
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.ApplicationId.Equals(key));



        }
        public override async Task<IEnumerable<CourseApplication>> GetAllAsync()
        {

            return await _set
               .Include(x => x.Applicant)
               .Include(x => x.Course)
               .AsNoTracking()
               .ToListAsync();

        }
        public override async Task<IEnumerable<CourseApplication>> GetAllWhereAsync(Expression<Func<CourseApplication, bool>> predicate)
        {

            return await _set
               .Include(x => x.Applicant)
               .Include(x => x.Course)
               .AsNoTracking()
               .ToListAsync();

        }

      


    }
}
