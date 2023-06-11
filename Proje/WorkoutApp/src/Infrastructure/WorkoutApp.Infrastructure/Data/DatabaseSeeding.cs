using WorkoutApp.Entities;

namespace WorkoutApp.Infrastructure.Data;

public static class DatabaseSeeding
{
    public static void SeedDatabase(WorkoutDbContext dbContext)
    {
        // if there are no categories in the database, add some
        seedCategories(dbContext);
        seedWorkouts(dbContext);
        seedUsers(dbContext);
    }

    private static void seedUsers(WorkoutDbContext dbContext)
    {
        if (!dbContext.Users.Any())
        {
            var users = new List<User>
            {
                new User() { Username = "admin", Email = "test@abc.com", Password = "zxcv", Role = "Admin", Name = "Admin" },
                new User() { Username = "user", Email = "test2@abc.com", Password = "zxcv", Role = "User", Name = "User" },
                new User() { Username = "editor",Email = "test3@abc.com", Password = "zxcv", Role = "Editor", Name = "Editor" },
            };
            dbContext.Users.AddRange(users);
            dbContext.SaveChanges();
        }
    }

    private static void seedCategories(WorkoutDbContext dbContext)
    {
        // if there are no categories in the database, add some
        if (!dbContext.Categories.Any())
        {
            var categories = new List<Category>
            {
                new Category { Name = "Omuz",},
                new Category { Name = "Trapez" },
                new Category { Name = "Göğüs" },
                new Category { Name = "Biceps" },
                new Category { Name = "Triceps" },
                new Category { Name = "Sırt" },
                new Category { Name = "Karın" },
                new Category { Name = "Bacak" },
                new Category { Name = "Ön Kol" },
            };
            dbContext.Categories.AddRange(categories);
            dbContext.SaveChanges();
        }
        
    }

    private static void seedWorkouts(WorkoutDbContext dbContext)
    {
        // if there are no workouts in the database, add some
        if (!dbContext.Workouts.Any())
        {
            var workouts = new List<Workout>
            {
                new Workout { Name = "Workout 1", Description = "Description 1", CategoryId = 1 },
                new Workout { Name = "Workout 2", Description = "Description 2", CategoryId = 2 },
                new Workout { Name = "Workout 3", Description = "Description 3", CategoryId = 3 },
            };
            dbContext.Workouts.AddRange(workouts);
            dbContext.SaveChanges();
        }
    }
}
        