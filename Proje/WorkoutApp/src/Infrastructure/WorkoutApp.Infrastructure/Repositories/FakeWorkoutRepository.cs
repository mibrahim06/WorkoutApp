namespace WorkoutApp.Infrastructure.Repositories;
using WorkoutApp.Entities;

/**
 * Fake repository for the Workout entity to be used for testing
 * @Warning: This is not a real repository, it is only used for testing purposes
 */
public class FakeWorkoutRepository : IWorkoutRepository
{
    private List<Workout> _workouts;

    public FakeWorkoutRepository()
    {
        _workouts = new()
        {
            new Workout() { Id = 1, Name = "Workout 1", Description = "Workout 1 Description", CategoryId = 1 },
            new Workout() { Id = 2, Name = "Workout 2", Description = "Workout 2 Description", CategoryId = 1 },
            new Workout() { Id = 3, Name = "Workout 3", Description = "Workout 3 Description", CategoryId = 2 },
            new Workout() { Id = 4, Name = "Workout 4", Description = "Workout 4 Description", CategoryId = 2 },
            new Workout() { Id = 5, Name = "Workout 5", Description = "Workout 5 Description", CategoryId = 3 },
            new Workout() { Id = 6, Name = "Workout 6", Description = "Workout 6 Description", CategoryId = 3 },
            new Workout() { Id = 7, Name = "Workout 7", Description = "Workout 7 Description", CategoryId = 1 },
            new Workout() { Id = 8, Name = "Workout 8", Description = "Workout 8 Description", CategoryId = 1 },
            new Workout() { Id = 9, Name = "Workout 9", Description = "Workout 9 Description", CategoryId = 1 },
            new Workout() { Id = 10, Name = "Workout 10", Description = "Workout 10 Description", CategoryId = 2 },
            new Workout() { Id = 11, Name = "Workout 11", Description = "Workout 11 Description", CategoryId = 2 },
            new Workout() { Id = 12, Name = "Workout 12", Description = "Workout 12 Description", CategoryId = 2 },
            new Workout() { Id = 13, Name = "Workout 13", Description = "Workout 13 Description", CategoryId = 3 },
            new Workout() { Id = 14, Name = "Workout 14", Description = "Workout 14 Description", CategoryId = 3 },
            new Workout() { Id = 15, Name = "Workout 15", Description = "Workout 15 Description", CategoryId = 3 },
            new Workout() { Id = 16, Name = "Workout 16", Description = "Workout 16 Description", CategoryId = 1 },
            new Workout() { Id = 17, Name = "Workout 17", Description = "Workout 17 Description", CategoryId = 1 },
            new Workout() { Id = 18, Name = "Workout 18", Description = "Workout 18 Description", CategoryId = 1 },
            new Workout() { Id = 19, Name = "Workout 19", Description = "Workout 19 Description", CategoryId = 2 },
            new Workout() { Id = 20, Name = "Workout 20", Description = "Workout 20 Description", CategoryId = 2 },
        };
    }
    public Task<Workout> GetByIdAsync(int id)
    {
        var workout = _workouts.FirstOrDefault(x => x.Id == id);
        return Task.FromResult(workout);
    }
    
    
    public Task<List<Workout>> GetAllAsync()
    {
        return Task.FromResult(_workouts);
    }

    public List<Workout> GetAll()
    {
        return _workouts;
    }

    public Task AddAsync(Workout entity)
    {
        var workout = _workouts.FirstOrDefault(x => x.Id == entity.Id);
        if (workout == null)
        {
            _workouts.Add(entity);
        }
        return Task.FromResult(entity);
    }

    public Task UpdateAsync(Workout entity)
    {
        var workout = _workouts.FirstOrDefault(x => x.Id == entity.Id);
        if (workout != null)
        {
            workout.Name = entity.Name;
            workout.Description = entity.Description;
            workout.CategoryId = entity.CategoryId;
        }
        return Task.FromResult(entity);
    }

    public Task DeleteAsync(Workout entity)
    {
        var workout = _workouts.FirstOrDefault(x => x.Id == entity.Id);
        if (workout != null)
        {
            _workouts.Remove(workout);
        }
        return Task.FromResult(entity);
    }

    public IEnumerable<Workout> GetWorkoutsByCategory(int categoryId)
    {
        var workouts = _workouts.Where(x => x.CategoryId == categoryId);
        return workouts;
    }

    public IEnumerable<Workout> GetWorkoutsByName(string name)
    {
        var workouts = _workouts.Where(x => x.Name.Contains(name));
        return workouts;
    }
}