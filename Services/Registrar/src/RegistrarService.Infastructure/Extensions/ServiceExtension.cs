using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RegistrarService.Application.Common.Mapper;
using RegistrarService.Application.Interfaces.Repositories;
using RegistrarService.Infastructure.Context;
using Microsoft.EntityFrameworkCore;
using RegistrarService.Infastructure.Repositories;

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

            services.AddAutoMapper(typeof(AccountProfile),typeof(EnrolmentProfile), typeof(CourseProfile));


            services.AddScoped<IUnitOfWork, UnitOfWork>();
            //services.AddScoped<IAccountRepository, AccountRepository>();




            return services;
        }
    }
}


