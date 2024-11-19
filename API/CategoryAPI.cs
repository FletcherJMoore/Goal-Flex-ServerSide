using Goal_Flex_ServerSide.Interfaces;
using Goal_Flex_ServerSide.Models;

namespace Goal_Flex_ServerSide.API
{
    public static class CategoryAPI
    {
        public static void MapCategoryAPI(this IEndpointRouteBuilder routes)

        {
            var group = routes.MapGroup("category").WithTags(nameof(Category));

            // Get all Categories.
            group.MapGet("/", async (ICategoryService categoryService) =>
            {
                try
                {
                    var categories = await categoryService.GetCategoriesAsync();
                    if (!categories.Any())
                    {
                        return Results.Ok(new List<Category>());
                    }
                    return Results.Ok(categories);
                }
                catch (ArgumentException ex)
                {
                    return Results.NotFound(ex.Message);
                }
            });
        }
    }
}
