using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using MMLib.SwaggerForOcelot.DependencyInjection;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Values;
using OcelotApiGateway;
using OcelotApiGateway.Extensions;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
//add appsetting file
builder.Host.ConfigureAppConfiguration(config =>
{
    config.AddJsonFile("appsetting.json");
    config.AddJsonFile("appsettings.Development.json");
});

var routes = "Routes";

builder.Configuration.AddOcelotWithSwaggerSupport(options =>
{
    options.Folder = routes;
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Configuration.AddJsonFile("configuration/ocelot.json", optional: false, reloadOnChange: true);
builder.Services.AddOcelot(builder.Configuration);

builder.Services.AddSwaggerForOcelotService(builder.Configuration);

var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
builder.Configuration.SetBasePath(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location))
    .AddOcelot(routes, builder.Environment)
    .AddEnvironmentVariables();


//swagger for ocelot
// Swagger for ocelot
builder.Services.AddSwaggerGen();


var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
}
//app.UseHttpsRedirection();

app.UseAuthorization();


app.UseSwaggerForOcelotUI(options =>
{
    options.PathToSwaggerGenerator = "/swagger/docs";
    options.ReConfigureUpstreamSwaggerJson = AlterUpstream.AlterUpstreamSwaggerJson;

}).UseOcelot().Wait();



app.MapControllers();



app.Run();