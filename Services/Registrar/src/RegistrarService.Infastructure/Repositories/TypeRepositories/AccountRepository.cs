using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RegistrarService.Application.Interfaces.Repositories.TypeRepositories;
using RegistrarService.Domain.Entities;
using RegistrarService.Infastructure.Context;

namespace RegistrarService.Infastructure.Repositories.TypeRepositories
{
    public class AccountRepository : GenericRepository<Student>, IAccountRepository
    {
        public AccountRepository(DataContext dbContext) : base(dbContext)
        {
        }

        public async Task<Student> CompleteEnrolment(Student entity)
        {
            var attached = await _set
                .Include(x => x.Enrolments)
                .SingleAsync(x => x.StudentId == entity.StudentId);

            _context.Entry(attached).State = EntityState.Detached;
            foreach (var enrolment in attached.Enrolments.ToList())
            {
                _context.Entry(enrolment).State = EntityState.Detached;
            }
            var entry = _context.Attach(entity);
            return entity;
        }

        public async Task<Student> CompleteRegistration(Student entity)
        {
            var attached = await _set
                .Include(x => x.Registrations)
                .Include(x => x.Enrolments)
                .SingleAsync(x => x.StudentId == entity.StudentId);

            _context.Entry(attached).State = EntityState.Detached;
            foreach (var registration in attached.Registrations.ToList())
            {
                _context.Entry(registration).State = EntityState.Detached;
            }
            _context.Entry(attached).State = EntityState.Detached;
            foreach (var enrolment in attached.Enrolments.ToList())
            {
                _context.Entry(enrolment).State = EntityState.Detached;
            }
            var entry = _context.Attach(entity);
            return entity;
        }

        public async Task<Student> AddCourseResults(Student entity)
        {
            var attached = await _set
                .Include(x => x.Transcript.Results)
                .SingleAsync(x => x.StudentId == entity.StudentId);

            _context.Entry(attached).State = EntityState.Detached;
            foreach (var result in attached.Transcript.Results.ToList())
            {
                _context.Entry(result).State = EntityState.Detached;
            }
            var entry = _context.Attach(entity);
            return entity;
        }
      
    }
}
