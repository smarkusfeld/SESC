using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StudentService.Application.Interfaces.Repositories.TypeRepositories;
using StudentService.Domain.Entities;
using StudentService.Infastructure.Context;

namespace StudentService.Infastructure.Repositories.TypeRepositories
{
    public class AccountRepository : GenericRepository<Account>, IAccountRepository
    {
        public AccountRepository(DataContext dbContext) : base(dbContext)
        {
        }

        public async Task<Account> CompleteEnrolment(Account entity)
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

        public async Task<Account> CompleteRegistration(Account entity)
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

        public async Task<Account> AddCourseResults(Account entity)
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
