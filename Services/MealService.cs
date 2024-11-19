using Goal_Flex_ServerSide.Interfaces;
using Goal_Flex_ServerSide.Models;
using Goal_Flex_ServerSide.DTOs;
using Goal_Flex_ServerSide.Repositories;

namespace Goal_Flex_ServerSide.Services
{
    public class MealService : IMealService
    {
        private readonly IMealRepository _mealRepository;

        public MealService(IMealRepository mealRepository)
        {
            _mealRepository = mealRepository;
        }
        public async Task<List<MealDTO>> GetMealsAsync()
        {
            var allMeals = await _mealRepository.GetMealsAsync();
            return allMeals
                 .Select(meal => new MealDTO(meal))
                 .ToList();
        }
        public async Task<Meal> GetMealByIdAsync(int mealId)
        {
            return await _mealRepository.GetMealByIdAsync(mealId);
        }
        public async Task<Meal> CreateMealAsync(Meal meal)
        {
            return await _mealRepository.CreateMealAsync(meal);
        }
        public async Task<Meal> UpdateMealAsync(Meal meal, int mealId)
        {
            return await _mealRepository.UpdateMealAsync(meal, mealId);
        }
        public async Task<Meal> DeleteMealAsync(int mealId)
        {
            return await _mealRepository.DeleteMealAsync(mealId);
        }
    }
}
