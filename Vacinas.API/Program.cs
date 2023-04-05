using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Vacina.API.Context;
using Vacinas.API.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ConsultaContext>(options => options.UseSqlServer("Server=DESKTOP-9V9EJ2R\\SQLEXPRESS;Database=bancoteste;TrustServerCertificate=True;Trusted_Connection=True"));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddScoped<IConsultaRepository, ConsultaRepository>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/*builder.Services.AddDbContext<ConsultaContext>(options => options.UseSqlServer("Server=DESKTOP-9V9EJ2R\\SQLEXPRESS;Database=bancoteste;Trusted_Connection=True"));*/


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
