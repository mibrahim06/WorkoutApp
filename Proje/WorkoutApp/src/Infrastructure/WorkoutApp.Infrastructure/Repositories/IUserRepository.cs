using WorkoutApp.Entities;

namespace WorkoutApp.Infrastructure.Repositories;

public interface IUserRepository : IRepository<User>
{
    public Task<User> GetUserByUsernamePasswordAsync(string username, string password);
}