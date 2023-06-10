using WorkoutApp.Entities;

namespace WorkoutApp.Infrastructure.Repositories;

public interface IRepository<T> where T : class, IEntity, new()
{
    Task<T> GetByIdAsync(int id);
    Task<List<T>> GetAllAsync();
    List<T> GetAll();
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}
