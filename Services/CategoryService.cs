using Goal_Flex_ServerSide.Interfaces;
using Goal_Flex_ServerSide.Models;

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

    }
}
