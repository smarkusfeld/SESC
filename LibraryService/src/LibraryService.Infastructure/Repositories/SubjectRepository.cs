using global::LibraryService.Application.Interfaces;
using global::LibraryService.Domain.Entities;
using global::LibraryService.Infastructure.Context;
using LibraryService.Application.Interfaces;
using LibraryService.Domain.Entities;
using LibraryService.Infastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Infastructure.Repositories
{
    public class SubjectRepository : GenericRepository<Subject>, ISubjectRepository
    {
        public SubjectRepository(DataContext dbContext) : base(dbContext)
        {

        }
    }
}