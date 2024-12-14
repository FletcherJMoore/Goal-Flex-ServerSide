using Goal_Flex_ServerSide.Data;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;
using Goal_Flex_ServerSide.Interfaces;
using Goal_Flex_ServerSide.Repositories;
using Goal_Flex_ServerSide.Services;
using Goal_Flex_ServerSide.API;
using Microsoft.EntityFrameworkCore.Migrations;
using Goal_Flex_ServerSide;


var builder = WebApplication.CreateBuilder(args);


// allows passing datetimes without time zone data 
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// allows our api endpoints to access the database through Entity Framework Core
builder.Services.AddNpgsql<GoalFlexDbContext>(builder.Configuration["GoalFlexDbConnectionString"]);


// Set the JSON serializer options
builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

builder.Services.AddScoped<IExerciseService, ExerciseService>();
builder.Services.AddScoped<IExerciseRepository, ExerciseRepository>();

builder.Services.AddScoped<IMealService, MealService>();
builder.Services.AddScoped<IMealRepository, MealRepository>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IWorkoutService, WorkoutService>();
builder.Services.AddScoped<IWorkoutRepository, WorkoutRepository>();

builder.Services.AddScoped<IWorkoutExerciseService, WorkoutExerciseService>();
builder.Services.AddScoped<IWorkoutExerciseRepository, WorkoutExerciseRepository>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:3000", "http://localhost:5003")
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseCors();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapCategoryAPI();
app.MapMealAPI();
app.MapWorkoutAPI();
app.MapExerciseAPI();
app.MapUserAPI();
app.MapWorkoutExerciseAPI();

app.Run();
