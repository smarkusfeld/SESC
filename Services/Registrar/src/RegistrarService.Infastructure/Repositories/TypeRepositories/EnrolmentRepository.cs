using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Identity.Client;
using RegistrarService.Application.Interfaces.Repositories.TypeRepositories;
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

namespace RegistrarService.Infastructure.Repositories.TypeRepositories
{
     public class EnrolmentRepository : GenericRepository<Enrolment>, IEnrolmentRepository
    {
        public EnrolmentRepository(DataContext dbContext) : base(dbContext)
        {

        }

        public override async Task<Enrolment?> GetAsync(object key)
        {

            return await _set
                .Include(x => x.CourseLevel)
                .Include(x => x.Student)
                .Include(x => x.CourseLevel.Course)
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id.Equals(key));

        }

        public override async Task<IEnumerable<Enrolment>> GetAllAsync()
        {

            return await _set
               .Include(x => x.CourseLevel)
               .Include(x => x.Student)
               .AsNoTracking()
               .ToListAsync();

        }

        public override async Task<Enrolment?> GetByAsync(Expression<Func<Enrolment, bool>> predicate)
        {

            return await _set
               .Include(x => x.CourseLevel)
               .Include(x => x.Student)
               .AsNoTracking()
               .SingleOrDefaultAsync(predicate);

        }

    
        public override async Task<IEnumerable<Enrolment>> GetAllWhereAsync(Expression<Func<Enrolment, bool>> predicate)
        {

            return await _set
               .Where(predicate)
               .Include(x => x.CourseLevel)
               .Include(x => x.Student)
               .AsNoTracking()
               .ToListAsync();

        }

    }
}
