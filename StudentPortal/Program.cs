using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using StudentPortal.Extensions;
using StudentPortal.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDISessionServices(builder.Configuration);

// register typed clients
//api gateway service 
builder.Services.AddHttpClient<GatewayService>(client =>
{
    client.BaseAddress = new Uri("http://student-gateway/");

    // using Microsoft.Net.Http.Headers;
    client.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
});

//identity service
builder.Services.AddHttpClient<IdentityService>(client =>
{
    client.BaseAddress = new Uri("http://identityservice/");

    // using Microsoft.Net.Http.Headers;
    client.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
});

builder.Services.AddControllersWithViews();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "StudentMicroservice Portal",
        Version = "v1",
        Description = "Student Service",
    });
    // allow xml comments to be seen on swagger UI
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFilename);
    options.IncludeXmlComments(xmlPath);

});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Student HTTP API v1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();
app.UseRouting();
app.UseSession();


//create single route 


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
