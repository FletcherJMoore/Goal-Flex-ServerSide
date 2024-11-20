namespace Goal_Flex_ServerSide.Models
{
    public class Meal
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Image {  get; set; }
        public string? Calories { get; set; }
        public string? Recipe { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }

    }
}
