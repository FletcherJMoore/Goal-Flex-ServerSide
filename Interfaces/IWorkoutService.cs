using Goal_Flex_ServerSide.DTOs;
using Goal_Flex_ServerSide.Models;

namespace Goal_Flex_ServerSide.Interfaces
{
    public interface IWorkoutService
    {
        Task<List<WorkoutDTO>> GetWorkoutsAsync();
        Task<Workout> GetWorkoutByIdAsync(int workoutId);
        Task<Workout> CreateWorkoutAsync(Workout workout);
        Task<Workout> UpdateWorkoutAsync(Workout story, int workoutId);
        Task<Workout> DeleteWorkoutAsync(int workoutId);
    }
}
