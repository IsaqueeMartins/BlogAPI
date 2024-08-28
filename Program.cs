using MySqlConnector;
using BlogAPI.Data;
using BlogAPI.Repositories.Interface;
using BlogAPI.Repositories;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ArtigoDBContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DataBase"), new MySqlServerVersion(new Version(8, 0, 21))));

builder.Services.AddScoped<IArtigosRepositorie, ArtigoRepositorie>();

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
