
using LibraryService.Application.Interfaces.Services;
using LibraryService.Application.Services;
using LibraryService.Infastructure.Context;
using LibraryService.Infastructure.Extensions;
using LibraryService.Portal.Middleware;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDIServices(builder.Configuration);
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<ILoanService, LoanService>();
builder.Services.AddScoped<ICatalogueService, CatalogueService>();

// add openlibrary service typed client class


//register typed clients
builder.Services.AddHttpClient<IISBNService, ISBNService>(client =>
    {
    //client.BaseAddress = new UriConfiguration["BaseURL"]);
    });


builder.Services.AddHttpClient<IFeeService, FeeService>();



builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "LibraryMicroservice",
        Version = "v1",
        Description = "Library Service",
    });
    // allow xml comments to be seen on swagger UI
    
});

var app = builder.Build();



//check that the database is created
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        // add 10 seconds delay to ensure the db server is up to accept connections
        System.Threading.Thread.Sleep(10000);
        var context = services.GetRequiredService<DataContext>();
        var created = context.Database.EnsureCreated();

    }
    catch (Exception ex)
    {
        var log = services.GetRequiredService<ILogger<Program>>();
        log.LogError(ex, "An error occurred creating the DB.");
    }
}
// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "LibraryMicroservice v1");
    options.RoutePrefix = string.Empty;
});

//app.UseHttpsRedirection();

//app.UseAuthorization();

// global error handler
app.UseMiddleware<ErrorHandlerMiddleware>();
app.MapControllers();

app.Run();