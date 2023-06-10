using WorkoutApp.Entities;

namespace WorkoutApp.Infrastructure.Data;

public static class DatabaseSeeding
{
    public static void SeedDatabase(WorkoutDbContext dbContext)
    {
        seedCategories(dbContext);
        seedWorkouts(dbContext);
    }

    private static void seedCategories(WorkoutDbContext dbContext)
    {
        // clean up the database before seeding
        dbContext.Categories.RemoveRange(dbContext.Categories);
        dbContext.SaveChanges();
        
        if (!dbContext.Categories.Any())
        {
            var category = new Category
            {
                Name = "Sample Category",
                Description = "This is a sample category",
            };
            dbContext.Categories.Add(category);
            dbContext.SaveChanges();
        }
        
    }

    private static void seedWorkouts(WorkoutDbContext dbContext)
    {
        // Clean up the database before seeding
        dbContext.Workouts.RemoveRange(dbContext.Workouts);
        dbContext.SaveChanges();
        
        if (!dbContext.Workouts.Any())
        {
            var workout = new Workout
            {
                Name = "Sample Workout",
                Description = "This is a sample workout",
                CategoryId = 1, // Mevcut bir kategori kimliği
            };
            dbContext.Workouts.Add(workout);
            dbContext.SaveChanges();
        }
    }
}
        