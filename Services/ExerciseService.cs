using Goal_Flex_ServerSide.DTOs;
using Goal_Flex_ServerSide.Interfaces;
using Goal_Flex_ServerSide.Models;
using Goal_Flex_ServerSide.Repositories;

namespace Goal_Flex_ServerSide.Services
{
    public class ExerciseService : IExerciseService
    {
        private readonly IExerciseRepository _exerciseRepository;

        public ExerciseService(IExerciseRepository exerciseRepository)
        {
            _exerciseRepository = exerciseRepository;
        }
        public async Task<List<ExerciseDTO>> GetExercisesAsync()
        {
            var allExercises = await _exerciseRepository.GetExercisesAsync();
            return allExercises
                 .Select(exercise => new ExerciseDTO(exercise))
                 .ToList();
        }
        public async Task<Exercise> GetExerciseByIdAsync(int exerciseId)
        {
            return await _exerciseRepository.GetExerciseByIdAsync(exerciseId);
        }
        public async Task<Exercise> CreateExerciseAsync(Exercise exercise)
        {
            return await _exerciseRepository.CreateExerciseAsync(exercise);
        }
        public async Task<Exercise> UpdateExerciseAsync(Exercise exercise, int exerciseId)
        {
            return await _exerciseRepository.UpdateExerciseAsync(exercise, exerciseId);
        }
        public async Task<Exercise> DeleteExerciseAsync(int exerciseId)
        {
            return await _exerciseRepository.DeleteExerciseAsync(exerciseId);
        }
    }
}
