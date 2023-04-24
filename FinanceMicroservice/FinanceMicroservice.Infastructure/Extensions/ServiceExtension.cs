using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FinanceMicroservice.Infastructure.Repositories;
using FinanceMicroservice.Core.Infastructure;
using FinanceMicroservice.Core.Interfaces;

namespace FinanceMicroservice.Infastructure
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddDIServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Default"));
            });
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IInvoiceRepository, InvoiceRepository>();

            return services;
        }
      
    }
}
