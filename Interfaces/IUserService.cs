using Goal_Flex_ServerSide.Models;

namespace Goal_Flex_ServerSide.Interfaces
{
    public interface IUserService
    {
        Task<User> CheckUserAsync(string userUid);
        Task<User> GetUserByIdAsync(int userId);
    }
}
