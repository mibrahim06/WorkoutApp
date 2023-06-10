using Microsoft.EntityFrameworkCore;
using WorkoutApp.Entities;

namespace WorkoutApp.Infrastructure.Data;

public class WorkoutDbContext : DbContext
{
    public DbSet<Workout> Workouts { get; set; }
    public DbSet<Category> Categories { get; set; }
    
    public WorkoutDbContext(DbContextOptions<WorkoutDbContext> options) : base(options)
    {
    }
}