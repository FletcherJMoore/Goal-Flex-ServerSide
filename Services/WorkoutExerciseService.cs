using Goal_Flex_ServerSide.Interfaces;
using Xunit.Sdk;

namespace Goal_Flex_ServerSide.Services
{
    public class WorkoutExerciseService : IWorkoutExerciseService
    {
        private readonly IWorkoutExerciseRepository _workoutExerciseRepository;

        public WorkoutExerciseService(IWorkoutExerciseRepository workoutExerciseRepository)
        {
            _workoutExerciseRepository = workoutExerciseRepository;
        }
        public async Task<(bool Success, string Message)> AddExerciseToWorkoutAsync(int exerciseId, int workoutId)
        {
            var workout = await _workoutExerciseRepository.GetWorkoutWithExercisesAsync(workoutId);
            if (workout == null)
            {
                return (false, $"There is no workout with the following id: {workoutId}");
            }
            var exercise = await _workoutExerciseRepository.GetExerciseByIdAsync(exerciseId);
            if (exercise == null)
            {
                return (false, $"There is no exercise with the following id: {exerciseId}");
            }

            if (workout.Exercises.Contains(exercise))
            {
                return (false, "This story already has this tag.");
            }
            await _workoutExerciseRepository.AddExerciseAsync(workout, exercise);
            return (true, "Tag added to the story successfully");

        }
        public async Task<(bool Success, string Message)> RemoveExerciseFromWorkoutAsync(int exerciseId, int workoutId)
        {
            var workout = await _workoutExerciseRepository.GetWorkoutWithExercisesAsync(workoutId);

            if (workout == null)
            {
                return (false, $"There is no workout with the following id: {workoutId}");
            }

            var exercise = await _workoutExerciseRepository.GetExerciseByIdAsync(exerciseId);

            if (exercise == null)
            {
                return (false, $"There is no exercise with the following id: {exerciseId}");
            }

            if (!workout.Exercises.Contains(exercise))
            {
                return (false, "This story does not have this tag.");
            }


            await _workoutExerciseRepository.RemoveExerciseAsync(workout, exercise);
            return (true, "Exercise removed from story successfully");
        }
    }
}
