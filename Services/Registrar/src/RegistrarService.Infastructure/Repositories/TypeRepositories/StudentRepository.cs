using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RegistrarService.Application.Interfaces.Repositories.TypeRepositories;
using RegistrarService.Domain.Entities;
using RegistrarService.Infastructure.Context;

namespace RegistrarService.Infastructure.Repositories.TypeRepositories
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        public StudentRepository(DataContext dbContext) : base(dbContext)
        {
        }
        public override async Task<Student> GetAsync(object key)
        {
            return await _set
                .AsNoTracking()
                .SingleAsync(x => x.StudentId.Equals(key));
        }

        public override async Task<Student> UpdateAsync(Student entity, object key)
        {
            if (entity == null)
                return null;
            Student exist = await _set.SingleOrDefaultAsync(x => x.StudentId.Equals(key));
            if (exist != null)
            {
                _context.Entry(exist).CurrentValues.SetValues(entity);
            }
            return exist;
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
          

        public async Task<Student> AddCourseResults(Student entity)
        {
            var attached = await _set
                .Include(x => x.Results)
                .SingleAsync(x => x.StudentId == entity.StudentId);

            _context.Entry(attached).State = EntityState.Detached;
            foreach (var result in attached.Results.ToList())
            {
                _context.Entry(result).State = EntityState.Detached;
            }
            var entry = _context.Attach(entity);
            return entity;
        }

    }
}
