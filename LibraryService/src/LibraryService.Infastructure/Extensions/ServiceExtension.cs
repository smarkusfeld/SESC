
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using LibraryService.Infastructure;
using LibraryService.Infastructure.Context;
using LibraryService.Application.Interfaces;
using LibraryService.Infastructure.Repositories;


namespace LibraryService.Infastructure.Extensions
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
            //services.AddAutoMapper(typeof(AccountProfile), typeof(InvoiceProfile), typeof(PaymentProfile));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IBookCopyRepository, BookCopyRepository>();
            services.AddScoped<ILoanRepository, LoanRepository>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<ITitleAuthorRepository,BookAuthorRepository>();

            return services;
        }
       

    }
}