using Goal_Flex_ServerSide.Models;

namespace Goal_Flex_ServerSide.DTOs
{
    public class WorkoutDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Image {  get; set; }
        public string Difficulty { get; set; }
        public WorkoutDTO(Workout workout)
        {
            Id = workout.Id;
            Title = workout.Title;
            Image = workout.Image;
            Difficulty = workout.Difficulty;
        }
    }
}
