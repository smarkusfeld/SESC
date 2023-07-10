using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using StudentService.Infastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentService.IntegrationTests
{
    public class TestingApiFactory<TEntryPoint> : WebApplicationFactory<Program> where TEntryPoint : Program
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType ==
                        typeof(DbContextOptions<DataContext>));

                if (descriptor != null)
                    services.Remove(descriptor);

                services.AddDbContext<DataContext>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryTest");
                });

                var sp = services.BuildServiceProvider();
                using (var scope = sp.CreateScope())
                using (var appContext = scope.ServiceProvider.GetRequiredService<DataContext>())
                {
                    try
                    {
                        appContext.Database.EnsureCreated();
                    }
                    catch (Exception ex)
                    {
                        
                        throw;
                    }
                }
            });
        }
    }
}
