using FitnessTracker.Infrastructure.Context;
using FitnessTracker.Core.Services;
using FitnessTracker.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using FluentValidation.AspNetCore;
using FitnessTracker.Core.Services.Interfaces;
using FitnessTracker.Core.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();

builder.Services.AddValidatorsFromAssemblyContaining<Program>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<FitnessDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IWorkoutRepository, WorkoutRepository>();
builder.Services.AddScoped<IWorkoutService, WorkoutService>();
builder.Services.AddScoped<IWorkoutExerciseRepository, WorkoutExerciseRepository>();
builder.Services.AddScoped<IWorkoutExerciseService, WorkoutExerciseService>();
builder.Services.AddScoped<IExerciseRepository, ExerciseRepository>();
builder.Services.AddScoped<IExerciseService, ExerciseService>();
builder.Services.AddScoped<IMuscleGroupRepository, MuscleGroupRepository>();
builder.Services.AddScoped<IMuscleGroupService, MuscleGroupService>();
builder.Services.AddScoped<IDifficultyLevelRepository, DifficultyLevelRepository>();
builder.Services.AddScoped<IDifficultyLevelService, DifficultyLevelService>();
builder.Services.AddScoped<IGoalRepository, GoalRepository>();
builder.Services.AddScoped<IGoalService, GoalService>();
builder.Services.AddScoped<IFoodItemRepository, FoodItemRepository>();
builder.Services.AddScoped<IFoodItemService, FoodItemService>();
builder.Services.AddScoped<IFoodLogRepository, FoodLogRepository>();
builder.Services.AddScoped<IFoodLogService, FoodLogService>();
builder.Services.AddScoped<IMeasurementLogRepository, MeasurementLogRepository>();
builder.Services.AddScoped<IMeasurementLogService, MeasurementLogService>();



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseAuthorization();
app.MapControllers();
app.Run();
