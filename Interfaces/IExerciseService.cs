using Goal_Flex_ServerSide.Models;
using Goal_Flex_ServerSide.DTOs;

namespace Goal_Flex_ServerSide.Interfaces
{
    public interface IExerciseService
    {
        Task<List<ExerciseDTO>> GetExercisesAsync();
        Task<Exercise> GetExerciseByIdAsync(int exerciseId);
        Task<Exercise> CreateExerciseAsync(Exercise exercise);
        Task<Exercise> UpdateExerciseAsync(Exercise exercise, int exerciseId);
        Task<Exercise> DeleteExerciseAsync(int exerciseId);
    }
}
