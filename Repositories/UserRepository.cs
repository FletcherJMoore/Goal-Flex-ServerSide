using Goal_Flex_ServerSide.Interfaces;
using Goal_Flex_ServerSide.Models;
using Microsoft.EntityFrameworkCore;

namespace Goal_Flex_ServerSide.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly GoalFlexDbContext dbContext;

        public UserRepository(GoalFlexDbContext context)
        {
            dbContext = context;
        }
        public async Task<User> CheckUserAsync(string userUid)
        {
            return await dbContext.Users.FirstOrDefaultAsync(u => u.Uid == userUid);
        }
        public async Task<User> GetUserByIdAsync(int userId)
        {
            return await dbContext.Users
              .Include(s => s.Workouts)
              .Include(s => s.Meals)
              .SingleOrDefaultAsync(u => u.Id == userId);
        }
    }
}
