using Microsoft.EntityFrameworkCore;
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
        
       

        public async Task<CourseLevel> UpdateCourseLevelAsync(CourseLevel entity)
        {
            var attached = await _context.Set<CourseLevel>()
                .Include(x => x.CourseModules)
                .Include(x => x.Sessions)
                .ThenInclude(x => x.SessionModules)
                .SingleAsync(x => x.Id == entity.Id);
            _context.Entry(attached).State = EntityState.Detached;
            foreach (var module in attached.CourseModules.ToList())
            {
                _context.Entry(module).State = EntityState.Detached;
            }
            foreach (var session in attached.Sessions.ToList())
            {
                _context.Entry(session).State = EntityState.Detached;
                foreach (var sessionmodule in session.SessionModules.ToList())
                {
                    _context.Entry(sessionmodule).State = EntityState.Detached;
                }
            }
            var entry = _context.Attach(entity);
            return entity;
        }
        public async Task<Course> UpdateContainedAwardsAsync(Course entity)
        {
            var attached = await _set
                .Include(x => x.ContainedAwards)
                .SingleAsync(x => x.Id == entity.Id);

            _context.Entry(attached).State = EntityState.Detached;
            foreach (var level in attached.CourseLevels.ToList())
            {
                _context.Entry(level).State = EntityState.Detached;
            }
            var entry = _context.Attach(entity);
            return entity;
        }  

        }
    }
}
