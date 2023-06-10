using Microsoft.EntityFrameworkCore;
using WorkoutApp.Entities;
using WorkoutApp.Infrastructure.Data;

namespace WorkoutApp.Infrastructure.Repositories;

public class EFWorkoutRepository : IWorkoutRepository
{
    private readonly WorkoutDbContext _dbContext;
    public EFWorkoutRepository(WorkoutDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public Task<Workout> GetByIdAsync(int id)
    {
        var workout = _dbContext.Workouts.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        return workout;
    }

    public Task<List<Workout>> GetAllAsync()
    {
        return _dbContext.Workouts.AsNoTracking().ToListAsync();
    }

    public List<Workout> GetAll()
    {
        return _dbContext.Workouts.AsNoTracking().ToList();
    }

    public async Task AddAsync(Workout entity)
    {
        var addingWorkout = await _dbContext.Workouts.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Workout entity)
    {
        var updatingWorkout = _dbContext.Workouts.Update(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Workout entity)
    {
        var deletingWorkout = await _dbContext.Workouts.FindAsync(entity.Id);
        _dbContext.Workouts.Remove(deletingWorkout);
        await _dbContext.SaveChangesAsync();
    }

    public IEnumerable<Workout> GetWorkoutsByCategory(int categoryId)
    {
        var workouts = _dbContext.Workouts.AsNoTracking().Where(x => x.CategoryId == categoryId);
        return workouts;
    }

    public IEnumerable<Workout> GetWorkoutsByName(string name)
    {
        var workouts = _dbContext.Workouts.AsNoTracking().Where(x => x.Name == name);
        return workouts;
    }
}