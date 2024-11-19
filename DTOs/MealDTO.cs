using Goal_Flex_ServerSide.Models;
namespace Goal_Flex_ServerSide.DTOs
{
    public class MealDTO
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Image { get; set; }
        public MealDTO(Meal meal)
        {
            Id = meal.Id;
            Title = meal.Title;
            Image = meal.Image;
        }
    }
}
