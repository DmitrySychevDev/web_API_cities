using Microsoft.EntityFrameworkCore;
using web_API.Models;


var builder = WebApplication.CreateBuilder(args);
string connection = @"Server=(localdb)\mssqllocaldb;Database=citiesBd;Trusted_Connection=True;";

// ????????? ???????? ApplicationContext ? ???????? ??????? ? ??????????
builder.Services.AddDbContext<CitiesContext>(options => options.UseSqlServer(connection));
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddRazorPages();// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRouting();
app.UseCors(builder => builder.AllowAnyOrigin());
app.UseEndpoints(endpoints => {
    endpoints.MapControllers();
});
app.UseHttpsRedirection();
app.UseDefaultFiles();
app.UseStaticFiles();
app.UseAuthorization();

app.MapControllers();

app.Run();
