using dotnet_db_api.Data;
using dotnet_db_api.Repository;
using dotnet_db_api.Repository.Impl;
using dotnet_db_api.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
//Register Controller to work
builder.Services.AddControllers();


//Register ApplicationDbContext for make ORM
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});


//Register Service to use but service is need register one by one not at all like controller
builder.Services.AddScoped<IStudentService, StudentService>();


//Register Repository to use and it same services too
builder.Services.AddScoped<IStudentRepository, StudentRepository>();


// Add services to the container.
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

//add this for work of route
app.MapControllers(); 
app.UseHttpsRedirection();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
