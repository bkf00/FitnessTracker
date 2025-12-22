using FitnessTracker.Core.Repositories;
using FitnessTracker.Infrastructure.Context;
using FitnessTracker.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using FluentValidation.AspNetCore;
using FitnessTracker.Core.Services;


var builder = WebApplication.CreateBuilder(args);

// Controllers + FluentValidation
builder.Services
    .AddControllers();
builder.Services.AddValidatorsFromAssemblyContaining<Program>();
builder.Services.AddFluentValidationAutoValidation();

// DbContext
builder.Services.AddDbContext<FitnessDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("FitnessDb")));

// Dependency Injection

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.CustomSchemaIds(type => type.FullName);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
