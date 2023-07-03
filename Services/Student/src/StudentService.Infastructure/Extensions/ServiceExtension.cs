using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StudentService.Application.Common.Mapper;
using StudentService.Application.Interfaces.Repositories;
using StudentService.Infastructure.Context;
using Microsoft.EntityFrameworkCore;
using StudentService.Infastructure.Repositories;

namespace StudentService.Infastructure.Extensions
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

            services.AddAutoMapper(typeof(StudentProfile), typeof(TranscriptProfile), typeof(EnrolmentProfile), typeof(CourseProfile));


            services.AddScoped<IUnitOfWork, UnitOfWork>();
            //services.AddScoped<IAccountRepository, AccountRepository>();




            return services;
        }
    }
}


