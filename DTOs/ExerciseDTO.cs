using Goal_Flex_ServerSide.Models;

namespace Goal_Flex_ServerSide.DTOs
{
    public class ExerciseDTO
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Image { get; set; }
        public ExerciseDTO(Exercise exercise) 
        {
            Id = exercise.Id;
            Title = exercise.Title;
            Image = exercise.Image;
        }
    }
}
