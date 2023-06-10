using WorkoutApp.Entities;

namespace WorkoutApp.Infrastructure.Repositories;

public interface IRepository<T> where T : class, IEntity, new()
{
    Task<T> GetByIdAsync(int id);
    Task<List<T>> GetAllAsync();
    List<T> GetAll();
    Task<T> AddAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<T> DeleteAsync(T entity);
}