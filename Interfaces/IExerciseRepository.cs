using Goal_Flex_ServerSide.Models;

namespace Goal_Flex_ServerSide.Interfaces
{
    public interface IExerciseRepository
    {
        Task<List<Exercise>> GetExercisesAsync();
        Task<Exercise> GetExerciseByIdAsync(int exerciseId);
        Task<Exercise> CreateExerciseAsync(Exercise exercise);
        Task<Exercise> UpdateExerciseAsync(Exercise exercise, int exerciseId);
        Task<Exercise> DeleteExerciseAsync(int exerciseId);
        Task<bool> UserExistsAsync(int userId);
    }
}
