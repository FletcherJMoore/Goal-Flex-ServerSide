using Castle.Components.DictionaryAdapter.Xml;
using Goal_Flex_ServerSide.Interfaces;
using Goal_Flex_ServerSide.Models;
using Goal_Flex_ServerSide.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Goal_Flex_ServerSide.Repositories
{
    public class WorkoutExerciseRepository : IWorkoutExerciseRepository
    {
        private readonly GoalFlexDbContext dbContext;

        public WorkoutExerciseRepository(GoalFlexDbContext context)
        {
            dbContext = context;
        }

        public async Task<Workout?> GetWorkoutWithExercisesAsync(int workoutId)
        {
            return await dbContext.Workouts
                .Include(s => s.Exercises)
                .FirstOrDefaultAsync(s => s.Id == workoutId);
        }

        public async Task<Exercise?> GetExerciseByIdAsync(int exerciseId)
        {
            return await dbContext.Exercises.FirstOrDefaultAsync(s => s.Id == exerciseId);
        }

        public async Task AddExerciseAsync(Workout workout, Exercise exercise)
        {
            workout.Exercises.Add(exercise);
            await dbContext.SaveChangesAsync();
        }

        public async Task RemoveExerciseAsync(Workout workout, Exercise exercise)
        {
            workout.Exercises.Remove(exercise);
            await dbContext.SaveChangesAsync();
        }
    }
}
