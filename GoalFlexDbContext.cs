using Microsoft.EntityFrameworkCore;
using Goal_Flex_ServerSide.Models;
using Goal_Flex_ServerSide.Data;
using System.Reflection.Emit;
using System.Xml.Linq;

namespace Goal_Flex_ServerSide
{
    public class GoalFlexDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Workout> Workouts { get; set; }


        public GoalFlexDbContext(DbContextOptions<GoalFlexDbContext> context) : base(context)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(CategoryData.Categories);

            modelBuilder.Entity<Exercise>().HasData(ExerciseData.Exercises);

            modelBuilder.Entity<User>().HasData(UserData.Users);

            modelBuilder.Entity<Meal>().HasData(MealData.Meals);

            modelBuilder.Entity<Workout>().HasData(WorkoutData.Workouts);
        }
    }
}
