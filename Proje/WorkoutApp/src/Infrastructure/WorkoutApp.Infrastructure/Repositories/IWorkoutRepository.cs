namespace WorkoutApp.Infrastructure.Repositories;
using WorkoutApp.Entities;

public interface IWorkoutRepository : IRepository<Workout>
{
    public IEnumerable<Workout> GetWorkoutsByCategory(int categoryId);
    public IEnumerable<Workout> GetWorkoutsByName(string name);
}