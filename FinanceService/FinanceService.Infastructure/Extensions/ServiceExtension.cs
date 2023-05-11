using FinanceService.Application.Interfaces;
using FinanceService.Application.Mapper;
using FinanceService.Infastructure.Context;
using FinanceService.Infastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using FinanceService.Infastructure;

namespace FinanceService.Application.Extensions
{ 
    public static class ServiceExtension
    {
        public static IServiceCollection AddDIServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["Finance:connectionString"];
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(connectionString);

            });
            services.AddAutoMapper(typeof(AccountProfile), typeof(InvoiceProfile), typeof(PaymentProfile));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IInvoiceRepository, InvoiceRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();

            return services;
        }

    }
}