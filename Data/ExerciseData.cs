using Goal_Flex_ServerSide.Models;
namespace Goal_Flex_ServerSide.Data
{
    public class ExerciseData
    {
        public static List<Exercise> Exercises = new()
        {
            new()
            {
                Id = 1,
                Title = "Push-Ups",
                Image = "http://dummyimage.com/250x150.png/ff0000/ffffff",
                Instructions = "Start in a plank position, lower your chest to the ground, and push back up.",
                UserId = 1
            },
            new()
            {
                Id = 2,
                Title = "Squats",
                Image = "http://dummyimage.com/250x150.png/00ff00/ffffff",
                Instructions = "Stand with feet shoulder-width apart, bend your knees, and lower your hips.",
                UserId = 2
            },
            new()
            {
                Id = 3,
                Title = "Plank",
                Image = "http://dummyimage.com/250x150.png/0000ff/ffffff",
                Instructions = "Hold your body in a straight line with your forearms and toes on the ground.",
                UserId = 3
            },
            new()
            {
                Id = 4,
                Title = "Bicep Curls",
                Image = "http://dummyimage.com/250x150.png/ffff00/000000",
                Instructions = "Hold weights in each hand and curl them toward your shoulders.",
                UserId = 4
            },
            new()
            {
                Id = 5,
                Title = "Lunges",
                Image = "http://dummyimage.com/250x150.png/ff00ff/ffffff",
                Instructions = "Step forward with one leg, bend both knees, and lower your body.",
                UserId = 5
            },
            new()
            {
                Id = 6,
                Title = "Jumping Jacks",
                Image = "http://dummyimage.com/250x150.png/00ffff/000000",
                Instructions = "Jump with your legs apart and your arms overhead, then return to the starting position.",
                UserId = 6
            },
            new()
            {
                Id = 7,
                Title = "Deadlifts",
                Image = "http://dummyimage.com/250x150.png/800080/ffffff",
                Instructions = "Lift a barbell or weights from the ground to your thighs while keeping your back straight.",
                UserId = 7
            },
            new()
            {
                Id = 8,
                Title = "Mountain Climbers",
                Image = "http://dummyimage.com/250x150.png/ffa500/000000",
                Instructions = "Start in a plank position and alternate bringing your knees toward your chest.",
                UserId = 8
            },
            new()
            {
                Id = 9,
                Title = "Burpees",
                Image = "http://dummyimage.com/250x150.png/008080/ffffff",
                Instructions = "From a standing position, drop to a squat, kick your legs back into a plank, and then jump back up.",
                UserId = 9
            },
            new()
            {
                Id = 10,
                Title = "Bench Press",
                Image = "http://dummyimage.com/250x150.png/c0c0c0/000000",
                Instructions = "Lie on a bench, lower the barbell to your chest, and press it back up.",
                UserId = 10
            }

        };
    }
}
