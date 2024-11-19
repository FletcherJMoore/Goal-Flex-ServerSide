using Goal_Flex_ServerSide.Interfaces;
using Goal_Flex_ServerSide.Models;
using Goal_Flex_ServerSide.DTOs;

namespace Goal_Flex_ServerSide.API
{
    public static class UserAPI
    {
        public static void MapUserAPI(this IEndpointRouteBuilder routes)

        {
            var group = routes.MapGroup("users").WithTags(nameof(User));

            group.MapGet("/checkUser/{uid}", async (IUserService userService, string uid) =>
            {
                User? userCheck = await userService.CheckUserAsync(uid);

                if (userCheck == null)
                {
                    return Results.NotFound("User is not registered");
                }
                return Results.Ok(new
                {
                    userCheck.Id,
                    userCheck.FirstName,
                    userCheck.LastName,
                    userCheck.Email,
                    userCheck.Image,
                    userCheck.Uid
                });
            });

            group.MapGet("/{userId}", async (IUserService userService, int userId) =>
            {
                User? user = await userService.GetUserByIdAsync(userId);

                if (user == null)
                {
                    return Results.NotFound($"There is no user with the following id: {userId}");
                }

                return Results.Ok(new
                {
                    user.Id,
                    user.FirstName,
                    user.LastName,
                    user.Image,
                    user.Username,
                    user.Email,
                    user.Uid,
                    Workouts = user.Workouts?.Select(workouts => new WorkoutDTO(workouts)).ToList(),
                    Meals = user.Meals?.Select(meals => new MealDTO(meals)).ToList(),
                });
            });
        }
    }
}
