using Goal_Flex_ServerSide.Interfaces;
using Goal_Flex_ServerSide.Models;
using Microsoft.EntityFrameworkCore;

namespace Goal_Flex_ServerSide.Repositories
{
    public class WorkoutRepository : IWorkoutRepository
    {
        private readonly GoalFlexDbContext dbContext;

        public WorkoutRepository(GoalFlexDbContext context)
        {
            dbContext = context;
        }
        public async Task<List<Workout>> GetWorkoutsAsync()
        {
            return await dbContext.Workouts.ToListAsync();
        }
        public async Task<Workout> GetWorkoutByIdAsync(int workoutId)
        {
            return await dbContext.Workouts
             .Include(s => s.Exercises)
             .Include(s => s.User)
             .SingleOrDefaultAsync(s => s.Id == workoutId);
        }
        public async Task<Workout> CreateWorkoutAsync(Workout workout)
        {
            await dbContext.Workouts.AddAsync(workout);
            await dbContext.SaveChangesAsync();
            return workout;
        }
        public async Task<Workout> UpdateWorkoutAsync(Workout workout, int workoutId)
        {
            throw new NotImplementedException();
        }
        public async Task<Workout> DeleteWorkoutAsync(int workoutId)
        {
            var workout = await dbContext.Workouts.SingleOrDefaultAsync(workout => workout.Id == workoutId);

            if (workout != null)
            {
                dbContext.Workouts.Remove(workout);
                await dbContext.SaveChangesAsync();
            }
            return workout;
        }
        public async Task<bool> CategoryExistsAsync(int categoryId)
        {
            return await dbContext.Categories.AnyAsync(category => category.Id == categoryId);
        }
        public async Task<bool> UserExistsAsync(int userId)
        {
            return await dbContext.Users.AnyAsync(user => user.Id == userId);
        }
    }
}
