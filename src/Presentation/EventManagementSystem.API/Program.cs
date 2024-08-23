using EventManagementSystem.Application.Extensions;
using EventManagementSystem.Application.Interfaces;
using EventManagementSystem.Application.IRepository;
using EventManagementSystem.Application.Services;
using EventManagementSystem.Domain.Entities;
using EventManagementSystem.Persistence;
using EventManagementSystem.Persistence.RegisterRepositories;
using EventManagementSystem.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContextFactory<EventManagementSystemContext>(
    o => o.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddScoped<IRepository<User>, UserRepository>();
//builder.Services.AddScoped<IService<User>, UserService>();


ServiceConfiguration.RegisterServices(builder.Services);
RepositoryConfiguration.RegisterRepositories(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

//app.MapGet("/{id}", (IUserService userService, [FromRoute] int id) =>
//{
//  return userService.Get(id);
//});

app.MapControllers();

app.Run();
