using Goal_Flex_ServerSide.Models;

namespace Goal_Flex_ServerSide.Interfaces
{
    public interface IWorkoutRepository
    {
        Task<List<Workout>> GetWorkoutsAsync();
        Task<Workout> GetWorkoutByIdAsync(int storyId);
        Task<Workout> CreateWorkoutAsync(Workout workout);
        Task<Workout> UpdateWorkoutAsync(Workout story, int workoutId);
        Task<Workout> DeleteWorkoutAsync(int workoutId);
    }
}
