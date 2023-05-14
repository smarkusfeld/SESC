
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using FinanceService.Infastructure;
using FinanceService.Infastructure.Context;
using FinanceService.Application.Mapper;
using FinanceService.Application.Interfaces;
using FinanceService.Infastructure.Repositories;

namespace FinanceService.Infastructure.Extensions
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
            services.AddAutoMapper(typeof(AutoMapperProfile),typeof(AccountProfile), typeof(InvoiceProfile), typeof(PaymentProfile));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IInvoiceRepository, InvoiceRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();

            return services;
        }

    }
}