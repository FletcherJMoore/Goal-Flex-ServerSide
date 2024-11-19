using Goal_Flex_ServerSide.Interfaces;
using Goal_Flex_ServerSide.Data;
using Goal_Flex_ServerSide.DTOs;
using Goal_Flex_ServerSide.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Services;
using Goal_Flex_ServerSide.Models;

namespace Goal_Flex_ServerSide.API

{
    public static class WorkoutAPI
    {
        public static void MapWorkoutAPI(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("workouts").WithTags(nameof(Workout));

            // Get all Workouts. (Returns WorkoutDTO)
            group.MapGet("/", async (IWorkoutService workoutService) =>
            {
                try
                {
                    var workoutDtos = await workoutService.GetWorkoutsAsync();
                    if (!workoutDtos.Any())
                    {
                        return Results.Ok(new List<WorkoutDTO>());
                    }
                    return Results.Ok(workoutDtos);
                }
                catch (ArgumentException ex)
                {
                    return Results.NotFound(ex.Message);
                }
            });

            // Get single Workout and it's excercises
            group.MapGet("/{workoutId}", async (IWorkoutService workoutService, int workoutId) =>
            {
                var workout = await workoutService.GetWorkoutByIdAsync(workoutId);

                if (workout == null)
                {
                    return Results.NotFound($"The workout with the following id was not found: {workoutId}");
                }

                return Results.Ok(new
                {
                    workout.Id,
                    workout.Title,
                    workout.Image,
                    workout.Time,
                    workout.Difficulty,
                    workout.UserId,
                    Exercises = workout.Exercises?.Select(exercise => new ExerciseDTO(exercise)).ToList(),
                    User = new UserDTO(workout.User),
                });
            });
        }
    }
}
