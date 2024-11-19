using Goal_Flex_ServerSide.Models;
namespace Goal_Flex_ServerSide.Data
{
    public class MealData
    {
        public static List<Meal> Meals = new()
        {
            new()
            {
                Id = 1,
                Title = "Grilled Chicken Salad",
                Image = "http://dummyimage.com/250x150.png/ff5733/ffffff",
                Calories = "350 kcal",
                Recipe = "Grill chicken breast and serve with mixed greens, cherry tomatoes, and vinaigrette.",
                UserId = 1
            },
            new()
            {
                Id = 2,
                Title = "Vegetable Stir-Fry",
                Image = "http://dummyimage.com/250x150.png/33ff57/ffffff",
                Calories = "200 kcal",
                Recipe = "Sauté mixed vegetables in olive oil with soy sauce and garlic.",
                UserId = 2
            },
            new()
            {
                Id = 3,
                Title = "Avocado Toast",
                Image = "http://dummyimage.com/250x150.png/3357ff/ffffff",
                Calories = "250 kcal",
                Recipe = "Toast whole-grain bread and top with mashed avocado and a sprinkle of salt.",
                UserId = 3
            },
            new()
            {
                Id = 4,
                Title = "Protein Smoothie",
                Image = "http://dummyimage.com/250x150.png/ffff33/000000",
                Calories = "300 kcal",
                Recipe = "Blend protein powder, banana, almond milk, and spinach.",
                UserId = 4
            },
            new()
            {
                Id = 5,
                Title = "Quinoa Bowl",
                Image = "http://dummyimage.com/250x150.png/ff33ff/ffffff",
                Calories = "400 kcal",
                Recipe = "Cook quinoa and top with black beans, corn, avocado, and salsa.",
                UserId = 5
            },
            new()
            {
                Id = 6,
                Title = "Oatmeal with Berries",
                Image = "http://dummyimage.com/250x150.png/33ffff/000000",
                Calories = "350 kcal",
                Recipe = "Cook oats and top with fresh berries and a drizzle of honey.",
                UserId = 6
            },
            new()
            {
                Id = 7,
                Title = "Grilled Salmon",
                Image = "http://dummyimage.com/250x150.png/663399/ffffff",
                Calories = "450 kcal",
                Recipe = "Season salmon fillet with olive oil, lemon, and dill, then grill until cooked.",
                UserId = 7
            },
            new()
            {
                Id = 8,
                Title = "Turkey Wrap",
                Image = "http://dummyimage.com/250x150.png/cc0000/ffffff",
                Calories = "300 kcal",
                Recipe = "Wrap turkey slices, lettuce, and hummus in a whole-grain tortilla.",
                UserId = 8
            },
            new()
            {
                Id = 9,
                Title = "Lentil Soup",
                Image = "http://dummyimage.com/250x150.png/66ff33/000000",
                Calories = "250 kcal",
                Recipe = "Simmer lentils with carrots, celery, onion, and vegetable broth.",
                UserId = 9
            },
            new()
            {
                Id = 10,
                Title = "Greek Yogurt Parfait",
                Image = "http://dummyimage.com/250x150.png/ff9933/000000",
                Calories = "200 kcal",
                Recipe = "Layer Greek yogurt with granola and fresh fruit in a glass.",
                UserId = 10
            }
        };
    }
}
