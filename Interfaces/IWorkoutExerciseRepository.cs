using Goal_Flex_ServerSide.Models;

namespace Goal_Flex_ServerSide.Interfaces
{
    public interface IWorkoutExerciseRepository
    {
        Task<Workout?> GetWorkoutWithExercisesAsync(int workoutId);
        Task<Exercise?> GetExerciseByIdAsync(int exerciseId);
        Task AddExerciseAsync(Workout workout, Exercise exercise);
        Task RemoveExerciseAsync(Workout workout, Exercise exercise);
    }
}
