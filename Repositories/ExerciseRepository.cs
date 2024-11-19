using Goal_Flex_ServerSide.Interfaces;
using Goal_Flex_ServerSide.Models;
using Microsoft.EntityFrameworkCore;
using Goal_Flex_ServerSide.DTOs;

namespace Goal_Flex_ServerSide.Repositories
{
    public class ExerciseRepository : IExerciseRepository
    {
        private readonly GoalFlexDbContext dbContext;

        public ExerciseRepository(GoalFlexDbContext context)
        {
            dbContext = context;
        }
        public async Task<List<Exercise>> GetExercisesAsync()
        {
            return await dbContext.Exercises.ToListAsync();
        }
        public async Task<Exercise> GetExerciseByIdAsync(int exerciseId)
        {
            return await dbContext.Exercises
             .SingleOrDefaultAsync(s => s.Id == exerciseId);
        }
        public async Task<Exercise> CreateExerciseAsync(Exercise exercise)
        {
            throw new NotImplementedException();
        }
        public async Task<Exercise> UpdateExerciseAsync(Exercise exercise, int exerciseId)
        {
            throw new NotImplementedException();
        }
        public async Task<Exercise> DeleteExerciseAsync(int exerciseId)
        {
            throw new NotImplementedException();
        }
    }
}
