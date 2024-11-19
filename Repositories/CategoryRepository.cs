using Goal_Flex_ServerSide.Data;
using Goal_Flex_ServerSide.Interfaces;
using Goal_Flex_ServerSide.Models;
using Microsoft.EntityFrameworkCore;

namespace Goal_Flex_ServerSide.Repositories
{
        public class CategoryRepository : ICategoryRepository
        {
            private readonly GoalFlexDbContext dbContext;

            public CategoryRepository(GoalFlexDbContext context)
            {
                dbContext = context;
            }

            public async Task<List<Category>> GetCategoriesAsync()
            {
            return await dbContext.Categories.ToListAsync();
            }
        }
}
