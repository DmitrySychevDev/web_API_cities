using Microsoft.EntityFrameworkCore;
using web_API.Models;


var builder = WebApplication.CreateBuilder(args);
string connection = @"Server=(localdb)\mssqllocaldb;Database=citiesBd;Trusted_Connection=True;";

// добавляем контекст ApplicationContext в качестве сервиса в приложение
builder.Services.AddDbContext<CitiesContext>(options => options.UseSqlServer(connection));
// Add services to the container.

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
