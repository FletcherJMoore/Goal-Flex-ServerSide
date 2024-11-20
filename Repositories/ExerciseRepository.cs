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
            await dbContext.Exercises.AddAsync(exercise);
            await dbContext.SaveChangesAsync();
            return exercise;
        }
        public async Task<Exercise> UpdateExerciseAsync(Exercise exercise, int exerciseId)
        {
            var existingExercise = await dbContext.Exercises.FindAsync(exerciseId);

            if (existingExercise == null)
            {
                return null;
            }

            existingExercise.Title = exercise.Title;
            existingExercise.Image = exercise.Image;
            existingExercise.Instructions = exercise.Instructions;
            existingExercise.UserId = exercise.UserId;

            await dbContext.SaveChangesAsync();

            return existingExercise;
        }
        public async Task<Exercise> DeleteExerciseAsync(int exerciseId)
        {
            var exercise = await dbContext.Exercises.SingleOrDefaultAsync(exercise => exercise.Id == exerciseId);

            if (exercise != null)
            {
                dbContext.Exercises.Remove(exercise);
                await dbContext.SaveChangesAsync();
            }
            return exercise;
        }
        public async Task<bool> UserExistsAsync(int userId)
        {
            return await dbContext.Users.AnyAsync(user => user.Id == userId);
        }
    }
}
