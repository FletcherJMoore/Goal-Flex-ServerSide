using Goal_Flex_ServerSide.Models;

namespace Goal_Flex_ServerSide.Interfaces
{
    public interface IWorkoutExerciseService
    {
        Task<(bool Success, string Message)> AddExerciseToWorkoutAsync(int exerciseId, int workoutId);
        Task<(bool Success, string Message)> RemoveExerciseFromWorkoutAsync(int exerciseId, int workoutId);
    }
}
