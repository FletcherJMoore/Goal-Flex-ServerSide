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
            public async Task<Category> CreateCategoryAsync(Category category)
            {
            await dbContext.Categories.AddAsync(category);
            await dbContext.SaveChangesAsync();
            return category;
        }
            public async Task<Category> UpdateCategoryAsync(Category category, int categoryId)
            {
                var existingCategory = await dbContext.Categories.FindAsync(categoryId);

            if (existingCategory == null)
            {
                return null;
            }
            existingCategory.Name = category.Name;

            await dbContext.SaveChangesAsync();

            return existingCategory;
        }
            public async Task<Category> DeleteCategoryAsync(int categoryId)
            {
            var category = await dbContext.Categories.SingleOrDefaultAsync(category => category.Id == categoryId);

            if (category != null)
            {
                dbContext.Categories.Remove(category);
                await dbContext.SaveChangesAsync();
            }
            return category;
        }
    }
}
