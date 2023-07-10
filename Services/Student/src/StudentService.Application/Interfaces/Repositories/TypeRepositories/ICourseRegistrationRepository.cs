using StudentService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentService.Application.Interfaces.Repositories.TypeRepositories
{
    public interface ICourseRegistrationRepository : IGenericRepository<CourseRegistration>
    {
    }
}
