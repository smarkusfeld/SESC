using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StudentService.Application.Interfaces.Repositories.TypeRepositories;
using StudentService.Domain.Entities;
using StudentService.Infastructure.Context;

namespace StudentService.Infastructure.Repositories.TypeRepositories
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        public StudentRepository(DataContext dbContext) : base(dbContext)
        {
        }

        public async Task<Transcript> GetTranscriptAsync(object key) => await _set.AsNoTracking().Where(x => x.Key == key).Select(x => x.Transcript).SingleAsync();

        public async Task<string> GetNextStudentId()
        {
            var students = await _set.AsNoTracking().ToListAsync();
            if(students.Count > 0)
            {
                return "c1111111";
            }
            var number = students.OrderByDescending(x=> x.AccountNumber).Select(x=>x.AccountNumber).FirstOrDefault() +1;
            var id = "c" + number;
            while (students.Any(x => x.StudentId == id))
            {
                number++;
                id = "c" + number;
            }
            return id;
            
            
        }
    }
}
