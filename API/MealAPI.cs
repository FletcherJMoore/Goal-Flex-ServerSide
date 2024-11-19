﻿using Goal_Flex_ServerSide.DTOs;
using Goal_Flex_ServerSide.Interfaces;
using Goal_Flex_ServerSide.Models;

namespace Goal_Flex_ServerSide.API
{
    public static class MealAPI
    {
        public static void MapMealAPI(this IEndpointRouteBuilder routes)

        {
            var group = routes.MapGroup("meals").WithTags(nameof(Meal));

            // Get all Meals. (Returns MealDTO)
            group.MapGet("/", async (IMealService mealService) =>
            {
                try
                {
                    var mealDtos = await mealService.GetMealsAsync();
                    if (!mealDtos.Any())
                    {
                        return Results.Ok(new List<MealDTO>());
                    }
                    return Results.Ok(mealDtos);
                }
                catch (ArgumentException ex)
                {
                    return Results.NotFound(ex.Message);
                }
            });

            // Get single Meal and it's User
            group.MapGet("/{mealId}", async (IMealService mealService, int mealId) =>
            {
                var meal = await mealService.GetMealByIdAsync(mealId) ;

                if (meal == null)
                {
                    return Results.NotFound($"The meal with the following id was not found: {mealId}");
                }

                return Results.Ok(new
                {
                   meal.Id,
                   meal.Title,
                   meal.Image,
                   meal.Calories,
                   meal.Recipe,
                   meal.UserId,
                   User = new UserDTO(meal.User),
                });
            });
        }
    }
}