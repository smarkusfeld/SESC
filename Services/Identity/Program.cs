using IdentityService.Extensions;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

ConfigurationManager configuration = builder.Configuration;
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "IdentityMicroservice",
        Version = "v1",
        Description = "Identity Service",
    });
    // allow xml comments to be seen on swagger UI
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFilename);
    options.IncludeXmlComments(xmlPath);

});

// Add Entity Framework Services
builder.Services.AddEntityDbService(builder.Configuration);

// Add Identity Services
builder.Services.AddIdentityService();

//Add Authentication Services with JWT
builder.Services.AddEntityDbService(builder.Configuration);

builder.Services.AddControllers();
//builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Identity HTTP API v1");
    options.RoutePrefix = string.Empty;
});

//app.UseHttpsRedirection();

//enable authentication and authorization
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();

