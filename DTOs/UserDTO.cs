using Goal_Flex_ServerSide.Models;

namespace Goal_Flex_ServerSide.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Image { get; set; }
        public UserDTO(User user)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Image = user.Image;
        }

    }
}
