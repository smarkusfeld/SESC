using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using LibraryService.Infastructure.Context;
using LibraryService.Infastructure.Repositories;
using LibraryService.Application.Interfaces.Repositories;
using LibraryService.Application.Common.Mapper;

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

            services.AddAutoMapper(typeof(AccountProfile), typeof(CatalogueProfile));


            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<ILoanRepository, LoanRepository>();            
            services.AddScoped<IReservationRepository, ReservationRepository>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IPublisherRepository, PublisherRepository>();
            services.AddScoped<ISubjectRepository, SubjectRepository>();

            

            return services;
        }


       




    }
}