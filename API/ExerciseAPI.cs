using Goal_Flex_ServerSide.Interfaces;
using Goal_Flex_ServerSide.Models;
using Goal_Flex_ServerSide.DTOs;

namespace Goal_Flex_ServerSide.API
{
    public static class ExerciseAPI
    {
        public static void MapExerciseAPI(this IEndpointRouteBuilder routes)

        {
            var group = routes.MapGroup("exercise").WithTags(nameof(Exercise));

            // Get all Exercises. (Returns ExerciseDTO)
            group.MapGet("/", async (IExerciseService exerciseService) =>
            {
                try
                {
                    var exercisesDtos = await exerciseService.GetExercisesAsync();
                    if (!exercisesDtos.Any())
                    {
                        return Results.Ok(new List<ExerciseDTO>());
                    }
                    return Results.Ok(exercisesDtos);
                }
                catch (ArgumentException ex)
                {
                    return Results.NotFound(ex.Message);
                }
            });

            // Get single Exercise
            group.MapGet("/{exerciseId}", async (IExerciseService exerciseService, int exerciseId) =>
            {
                var exercise = await exerciseService.GetExerciseByIdAsync(exerciseId);

                if (exercise == null)
                {
                    return Results.NotFound($"The Exercise with the following id was not found: {exerciseId}");
                }

                return Results.Ok(new
                {
                    exercise.Id,
                    exercise.Title,
                    exercise.Image,
                    exercise.Instructions,
                    exercise.UserId
                });
            });
        }
    }
}
