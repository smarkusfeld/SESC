
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using LibraryService.Infastructure;
using LibraryService.Infastructure.Context;
using LibraryService.Application.Interfaces;
using LibraryService.Infastructure.Repositories;
using LibraryService.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

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
            services.AddIdentity<User, IdentityRole>(opt =>
            {
                opt.SignIn.RequireConfirmedAccount = false; 
                opt.Password.RequireDigit = true;
                opt.Password.RequiredUniqueChars = 0;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequiredLength = 6;

            }).AddEntityFrameworkStores<DataContext>()
            //.AddDefaultUI()
            .AddDefaultTokenProviders();




            //services.AddAutoMapper(typeof(AccountProfile), typeof(InvoiceProfile), typeof(PaymentProfile));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IBookCopyRepository, BookCopyRepository>();
            services.AddScoped<ILoanRepository, LoanRepository>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IBookAuthorRepository,BookAuthorRepository>();
            //services.AddAuthentication(o =>
            //{
            //    o.DefaultScheme = IdentityConstants.ApplicationScheme;
            //    o.DefaultSignInScheme = IdentityConstants.ExternalScheme;
            //}).AddIdentityCookies(o => { });

            //services.AddIdentityCore<User>(o =>
            //{
            //    o.Stores.MaxLengthForKeys = 128;
            //    o.SignIn.RequireConfirmedAccount = true;
            //}).AddDefaultTokenProviders();

            return services;
        }
       

    }
}