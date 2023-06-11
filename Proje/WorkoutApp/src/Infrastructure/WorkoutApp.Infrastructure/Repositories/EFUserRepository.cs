using Microsoft.EntityFrameworkCore;
using WorkoutApp.Entities;
using WorkoutApp.Infrastructure.Data;

namespace WorkoutApp.Infrastructure.Repositories;

public class EFUserRepository : IUserRepository
{
    private readonly WorkoutDbContext _dbContext;
    public EFUserRepository(WorkoutDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public Task<User> GetByIdAsync(int id)
    {
        var user = _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        return user;
    }

    public Task<List<User>> GetAllAsync()
    {
        return _dbContext.Users.AsNoTracking().ToListAsync();
    }

    public List<User> GetAll()
    {
        return _dbContext.Users.AsNoTracking().ToList();
    }

    public async Task AddAsync(User entity)
    {
         var addingUser = _dbContext.Users.AddAsync(entity);
         await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(User entity)
    {
        var updatingUser = _dbContext.Users.Update(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(User entity)
    {
        var deletingUser = await _dbContext.Users.FindAsync(entity.Id);
        _dbContext.Users.Remove(deletingUser);
        await _dbContext.SaveChangesAsync();
    }
    
    public async Task<User> GetUserByUsernamePasswordAsync(string username, string password)
    {
        var user = await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Username == username && x.Password == password);
        return user;
    }
}