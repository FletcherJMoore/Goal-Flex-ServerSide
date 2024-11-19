using Goal_Flex_ServerSide.Interfaces;
using Goal_Flex_ServerSide.Models;

namespace Goal_Flex_ServerSide.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<User> CheckUserAsync(string userUid)
        {
            return await _userRepository.CheckUserAsync(userUid);
        }
        public async Task<User> GetUserByIdAsync(int userId)
        {
            return await _userRepository.GetUserByIdAsync(userId);
        }
    }
}
