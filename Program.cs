using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ProfileService.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddControllers();
//builder.Services.AddDbContext<ProfileContext>(options => options.UseInMemoryDatabase("ProfileView"));

/*
IConfiguration configuration = builder.Configuration;

var server = configuration["DbServer"] ?? "localhost";
var port = configuration["Dbport"] ?? "1433";
var user = configuration["DbUser"] = "SA";
var pwd = configuration["DbPwd"] = "C0mp2001!";
var database = configuration["Db"] = "workshop5";


builder.Services.AddDbContext<ProfileContext>(options => 
options.UseSqlServer($"Server = {server}, {port}; Initial Catalog = {database}; User Id={user};Password={pwd}"));
*/

builder.Services.AddDbContext<ProfileContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ApiConnectionString"),
        sqlServerOptions =>
        {
            sqlServerOptions.EnableRetryOnFailure();
        });
});


/*
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


var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
*/

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
