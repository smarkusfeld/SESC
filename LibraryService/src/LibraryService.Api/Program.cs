using LibraryService.Api.Middleware;
using LibraryService.Application.Interfaces;
using LibraryService.Application.Services;
using LibraryService.Infastructure.Context;
using LibraryService.Infastructure.Extensions;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDIServices(builder.Configuration);

// add openlibrary service typed client class


//register typed clients
builder.Services.AddHttpClient<ICatalogueService, CatalogueService>();
builder.Services.AddHttpClient<IFeeService, FeeService>();

builder.Services.AddTransient<ExceptionMiddleware>();
builder.Services.ConfigureLoggerService();


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
    //var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    //options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

var app = builder.Build();
var logger = app.Services.GetRequiredService<ILoggerManager>();


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
        //var log = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred creating the DB.");
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

app.MapControllers();

app.Run();