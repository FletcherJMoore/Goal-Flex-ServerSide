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
            throw new NotImplementedException();
        }
        public async Task<Workout> UpdateWorkoutAsync(Workout workout, int workoutId)
        {
            throw new NotImplementedException();
        }
        public async Task<Workout> DeleteWorkoutAsync(int workoutId)
        {
            throw new NotImplementedException();
        }
    }
}
