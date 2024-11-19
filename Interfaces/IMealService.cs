using Goal_Flex_ServerSide.Models;
using Goal_Flex_ServerSide.DTOs;

namespace Goal_Flex_ServerSide.Interfaces
{
    public interface IMealService
    {
        Task<List<MealDTO>> GetMealsAsync();
        Task<Meal> GetMealByIdAsync(int mealId);
        Task<Meal> CreateMealAsync(Meal meal);
        Task<Meal> UpdateMealAsync(Meal meal, int mealId);
        Task<Meal> DeleteMealAsync(int mealId);
    }
}
