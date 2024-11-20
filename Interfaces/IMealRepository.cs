using Goal_Flex_ServerSide.Models;

namespace Goal_Flex_ServerSide.Interfaces
{
    public interface IMealRepository
    {
        Task<List<Meal>> GetMealsAsync();
        Task<Meal> GetMealByIdAsync(int mealId);
        Task<Meal> CreateMealAsync(Meal meal);
        Task<Meal> UpdateMealAsync(Meal meal, int mealId);
        Task<Meal> DeleteMealAsync(int mealId);
        Task<bool> UserExistsAsync(int userId);

    }
}
