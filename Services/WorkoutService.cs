using Goal_Flex_ServerSide.Interfaces;
using Goal_Flex_ServerSide.Models;
using Goal_Flex_ServerSide.Repositories;
using Goal_Flex_ServerSide.DTOs;

namespace Goal_Flex_ServerSide.Services
{
    public class WorkoutService : IWorkoutService
    {
        private readonly IWorkoutRepository _workoutRepository;

        public WorkoutService(IWorkoutRepository workoutRepository)
        {
            _workoutRepository = workoutRepository;
        }
        public async Task<List<WorkoutDTO>> GetWorkoutsAsync()
        {
            var allWorkouts = await _workoutRepository.GetWorkoutsAsync();
            return allWorkouts
                 .Select(workout => new WorkoutDTO(workout))
                 .ToList();
        }
        public async Task<Workout> GetWorkoutByIdAsync(int workoutId)
        {
            return await _workoutRepository.GetWorkoutByIdAsync(workoutId);
        }
        public async Task<Workout> CreateWorkoutAsync(Workout workout)
        {
            return await _workoutRepository.CreateWorkoutAsync(workout);
        }
        public async Task<Workout> UpdateWorkoutAsync(Workout workout, int workoutId)
        {
            return await _workoutRepository.UpdateWorkoutAsync(workout, workoutId);
        }
        public async Task<Workout> DeleteWorkoutAsync(int workoutId)
        {
            return await _workoutRepository.DeleteWorkoutAsync(workoutId);
        }
    }
}
