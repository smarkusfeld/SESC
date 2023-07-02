using IdentityService.Extensions;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

ConfigurationManager configuration = builder.Configuration;
builder.Services.AddSwaggerGen();

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
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//enable authentication and authorization
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();

