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
            throw new NotImplementedException();
        }
        public async Task<Meal> UpdateMealAsync(Meal meal, int mealId)
        {
            throw new NotImplementedException();
        }
        public async Task<Meal> DeleteMealAsync(int mealId)
        {
            throw new NotImplementedException();
        }
    }
}
