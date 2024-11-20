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

            // Create new category
            group.MapPost("/", async (ICategoryService categoryService, Category newCategory) =>
            {
                try
                {
                    var createdCategory = await categoryService.CreateCategoryAsync(newCategory);
                    return Results.Ok(createdCategory);
                }
                catch (ArgumentException ex)
                {
                    return Results.NotFound(ex.Message);
                }
            });

            //Delete category
            group.MapDelete("/{categoryId}", async (ICategoryService categoryService, int categoryId) =>
            {
                var categoryToDelete = await categoryService.DeleteCategoryAsync(categoryId);
                if (categoryToDelete == null)
                {
                    return Results.NotFound($"There is no category with a matching id of: {categoryId}");
                }
                return Results.Ok(categoryToDelete);

            });
        }
    }
}
