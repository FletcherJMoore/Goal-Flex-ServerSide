using Goal_Flex_ServerSide.Models;

namespace Goal_Flex_ServerSide.Interfaces
{
    public interface ICategoryService
    {
        Task<List<Category>> GetCategoriesAsync();
    }
}
