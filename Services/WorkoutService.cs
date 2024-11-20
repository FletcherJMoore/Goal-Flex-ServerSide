using Goal_Flex_ServerSide.Interfaces;
using Goal_Flex_ServerSide.Models;
using Goal_Flex_ServerSide.Repositories;
using Goal_Flex_ServerSide.DTOs;
using Microsoft.EntityFrameworkCore.Migrations;

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
            if (!await _workoutRepository.UserExistsAsync(workout.UserId))
            {
                throw new ArgumentException($"There is no user with the following id: {workout.UserId}");
            }

            if (!await _workoutRepository.CategoryExistsAsync(workout.CategoryId))
            {
                throw new ArgumentException($"There are no categories with the following id: {workout.CategoryId}");
            }

            Workout newWorkout = new()
            {
                Title = workout.Title,
                Image = workout.Image,
                Time = workout.Time,
                Difficulty = workout.Difficulty,
                UserId = workout.UserId,
                CategoryId = workout.CategoryId,
            };
            return await _workoutRepository.CreateWorkoutAsync(newWorkout);
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
