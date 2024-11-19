namespace Goal_Flex_ServerSide.Models
{
    public class Workout
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Image {  get; set; }
        public string? Time {  get; set; }
        public string? Difficulty { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public List<Exercise> Exercises { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
