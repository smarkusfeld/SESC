
using FinanceService.Application.Interfaces;
using FinanceService.Application.Services;
using FinanceService.Infastructure.Context;
using FinanceService.Infastructure.Extensions;
using Microsoft.OpenApi.Models;
using NLog;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDIServices(builder.Configuration);
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IInvoiceService, InvoiceService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "FinanceMicroservice",
        Version = "v1",
        Description = "Finance Service",
    });
    // allow xml comments to be seen on swagger UI
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFilename);
    options.IncludeXmlComments(xmlPath);
});


var app = builder.Build();
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

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Finance HTTP API v1");
    options.RoutePrefix = string.Empty;
});

//app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();
