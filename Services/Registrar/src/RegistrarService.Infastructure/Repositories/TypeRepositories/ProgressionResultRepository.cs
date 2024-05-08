using RegistrarService.Application.Interfaces.Repositories.TypeRepositories;
using RegistrarService.Domain.Entities;
using RegistrarService.Infastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrarService.Infastructure.Repositories.TypeRepositories
{
     public class ProgressionResultRepository : GenericRepository<ProgressionResult>, IProgressionResultRepository
    {
        public ProgressionResultRepository(DataContext dbContext) : base(dbContext)
        {

        }
    }
}
