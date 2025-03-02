using Microsoft.Build.Framework;
using TaskAdministratorAPI.Controllers;
using TaskAdministratorAPI.iservices;
using TaskAdministratorAPI.repositories;
using TaskAdministratorAPI.repositories.models;
using TaskAdministratorAPI.services;

var builder = WebApplication.CreateBuilder(args);
var services = new ServiceCollection();

// Add services to the container.
builder.Services.AddSingleton<TaskRepository, TaskRepository>();
builder.Services.AddTransient<ITaskService, TaskService>();
builder.Services.AddTransient<TaskController, TaskController>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//configure enviroment variables
var dbConfig = builder.Configuration.GetSection("DB");
builder.Services.Configure<Config>(dbConfig);
var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
