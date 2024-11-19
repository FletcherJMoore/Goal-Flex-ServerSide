using Goal_Flex_ServerSide.Models;
namespace Goal_Flex_ServerSide.Data
{
    public class CategoryData
    {
        public static List<Category> Categories = new()
        {
            new()
            {
                Id = 1,
                Name = "Strength Training"
            },
            new()
            {
                Id = 2,
                Name = "Cardio"
            },
            new()
            {
                Id = 3,
                Name = "Flexibility"
            },
            new()
            {
                Id = 4,
                Name = "Endurance"
            },
            new()
            {
                Id = 5,
                Name = "HIIT"
            },
            new()
            {
                Id = 6,
                Name = "Core"
            },
            new()
            {
                Id = 7,
                Name = "Plyometrics"
            },
            new()
            {
                Id = 8,
                Name = "Weight Loss"
            },
            new()
            {
                Id = 9,
                Name = "Mobility"
            },
            new()
            {
                Id = 10,
                Name = "Rehabilitation"
            }
        };
    }
}
