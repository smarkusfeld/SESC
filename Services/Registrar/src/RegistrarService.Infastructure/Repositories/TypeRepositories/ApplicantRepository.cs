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
    public class ApplicantRepository : GenericRepository<Applicant>, IApplicantRepository
    {
        public ApplicantRepository(DataContext dbContext) : base(dbContext)
        {

        }

        public Task<Applicant> SubmitApplication(Applicant entity)
        {
            throw new NotImplementedException();
        }

        public Task<CourseApplication> UpdateApplication(CourseApplication entity)
        {
            throw new NotImplementedException();
        }
    }
}
