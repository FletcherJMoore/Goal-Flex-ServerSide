using Goal_Flex_ServerSide.Interfaces;
using Goal_Flex_ServerSide.Models;
using Microsoft.EntityFrameworkCore;

namespace Goal_Flex_ServerSide.Repositories
{
    public class MealRepository : IMealRepository
    {
        private readonly GoalFlexDbContext dbContext;

        public MealRepository(GoalFlexDbContext context)
        {
            dbContext = context;
        }
        public async Task<List<Meal>> GetMealsAsync()
        {
            return await dbContext.Meals.ToListAsync();
        }
        public async Task<Meal> GetMealByIdAsync(int mealId)
        {
            return await dbContext.Meals
             .Include(s => s.User)
             .SingleOrDefaultAsync(s => s.Id == mealId);
        }
        public async Task<Meal> CreateMealAsync(Meal meal)
        {
            await dbContext.Meals.AddAsync(meal);
            await dbContext.SaveChangesAsync();
            return meal;
        }
        public async Task<Meal> UpdateMealAsync(Meal meal, int mealId)
        {
            var existingMeal = await dbContext.Meals.FindAsync(mealId);

            if (existingMeal == null)
            {
                return null;
            }

            existingMeal.Title = meal.Title;
            existingMeal.Image = meal.Image;
            existingMeal.Calories = meal.Calories;
            existingMeal.Recipe = meal.Recipe;
            existingMeal.UserId = meal.UserId;

            await dbContext.SaveChangesAsync();

            return existingMeal;
        }
        public async Task<Meal> DeleteMealAsync(int mealId)
        {
            var meal = await dbContext.Meals.SingleOrDefaultAsync(meal => meal.Id == mealId);

            if (meal != null)
            {
                dbContext.Meals.Remove(meal);
                await dbContext.SaveChangesAsync();
            }
            return meal;
        }
        public async Task<bool> UserExistsAsync(int userId)
        {
            return await dbContext.Users.AnyAsync(user => user.Id == userId);
        }
    }
}
