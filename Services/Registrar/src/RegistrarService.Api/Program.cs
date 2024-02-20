using Microsoft.OpenApi.Models;
using RegistrarService.Application.Interfaces.Services;
using RegistrarService.Application.Services;
using RegistrarService.Infastructure.Context;
using RegistrarService.Infastructure.Extensions;
using RegistrarService.Service.Middleware;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDIServices(builder.Configuration);
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<IEnrolService, EnrolService>();

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "StudentMicroservice",
        Version = "v1",
        Description = "Student Service",
    });
    // allow xml comments to be seen on swagger UI
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFilename);
    options.IncludeXmlComments(xmlPath);

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
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Student HTTP API v1");
    options.RoutePrefix = string.Empty;
});

//app.UseHttpsRedirection();

//app.UseAuthorization();

// global error handler
app.UseMiddleware<ErrorHandlerMiddleware>();
app.MapControllers();

app.Run();