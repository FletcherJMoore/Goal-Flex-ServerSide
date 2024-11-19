namespace Goal_Flex_ServerSide.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Image { get; set; }
        public string? Email { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Username { get; set; }
        public string? Uid { get; set; }
        public List<Meal> Meals { get; set; }
        public List<Workout> Workouts { get; set; }
    }
}
