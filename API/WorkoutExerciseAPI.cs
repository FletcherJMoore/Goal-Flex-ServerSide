using Goal_Flex_ServerSide.Models;
using Goal_Flex_ServerSide.Interfaces;
using Goal_Flex_ServerSide.Services;

namespace Goal_Flex_ServerSide.API
{
    public static class WorkoutExerciseAPI
    {
        public static void MapWorkoutExerciseAPI(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("workouts").WithTags("WorkoutExercise");

            group.MapPost("/{workoutId}/add-exercise/{exerciseId}", async (IWorkoutExerciseService workoutExerciseService, int exerciseId, int workoutId) =>
            {
                var (success, message) = await workoutExerciseService.AddExerciseToWorkoutAsync(exerciseId, workoutId);
                if (success)
                {
                    return Results.Ok(message);
                }
                else if (message.Contains("with following id"))
                {
                    return Results.NotFound(message);
                }
                else
                {
                    return Results.Conflict(message);
                }
            });

            group.MapDelete("/{workoutId}/remove-exercise/{exerciseId}", async (IWorkoutExerciseService workoutExerciseService, int exerciseId, int workoutId) =>
            {
                var (success, message) = await workoutExerciseService.RemoveExerciseFromWorkoutAsync(exerciseId, workoutId);
                if (success)
                {
                    return Results.Ok(message);
                }
                else if (message.Contains("with following id"))
                {
                    return Results.NotFound(message);
                }
                else
                {
                    return Results.Conflict(message);
                }
            });

        }
    }
}
