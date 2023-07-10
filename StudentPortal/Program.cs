using Microsoft.Net.Http.Headers;
using StudentPortal.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// register typed clients - api gateway 
builder.Services.AddHttpClient<StudentService>(client =>
{
    client.BaseAddress = new Uri("http://student.api/");

    // using Microsoft.Net.Http.Headers;
    client.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
