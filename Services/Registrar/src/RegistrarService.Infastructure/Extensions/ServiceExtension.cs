using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RegistrarService.Application.Common.Mapper;
using RegistrarService.Application.Interfaces.Repositories;
using RegistrarService.Infastructure.Context;
using Microsoft.EntityFrameworkCore;
using RegistrarService.Infastructure.Repositories;
using RegistrarService.Infastructure.Repositories.TypeRepositories;
using RegistrarService.Application.Interfaces.Repositories.TypeRepositories;

namespace RegistrarService.Infastructure.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddDIServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connection = configuration.GetConnectionString("Default");
            services.AddDbContext<DataContext>(options =>
            {
                options.UseMySQL(connection);

            });

            services.AddAutoMapper(typeof(AddressProfile), typeof(StudentProfile),typeof(EnrolmentProfile), typeof(CourseProfile), typeof(ApplicantProfile),typeof(ApplicationProfile));


            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IApplicantRepository, ApplicantRepository>();
            services.AddScoped<IAwardRepository, AwardRepository>();
            services.AddScoped<ICourseApplicationRepository, CourseApplicationRepository>();
            services.AddScoped<IEnrolmentRepository, EnrolmentRepository>();
            services.AddScoped <ProgrammeRepository, ProgrammeRepository>();
            services.AddScoped<IProgressionResultRepository, ProgressionResultRepository>();
            services.AddScoped <ISchoolRepository, SchoolRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<ISubjectRepository, SubjectRepository>();

            return services;
        }
    }
}


