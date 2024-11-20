using Goal_Flex_ServerSide.Interfaces;
using Goal_Flex_ServerSide.Models;
using Goal_Flex_ServerSide.Repositories;

namespace Goal_Flex_ServerSide.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<List<Category>> GetCategoriesAsync()
        {
            return await _categoryRepository.GetCategoriesAsync();
        }
        public async Task<Category> CreateCategoryAsync(Category category)
        {
            Category newCategory = new()
            {
                Name = category.Name,
            };
            return await _categoryRepository.CreateCategoryAsync(newCategory);
        }
        public async Task<Category> UpdateCategoryAsync(Category category, int categoryId)
        {
            return await _categoryRepository.UpdateCategoryAsync(category, categoryId);
        }
        public async Task<Category> DeleteCategoryAsync(int categoryId)
        {
            return await _categoryRepository.DeleteCategoryAsync(categoryId);
        }
    }
}
