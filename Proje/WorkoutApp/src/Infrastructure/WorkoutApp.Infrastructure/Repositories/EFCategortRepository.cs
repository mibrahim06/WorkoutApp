using Microsoft.EntityFrameworkCore;
using WorkoutApp.Entities;
using WorkoutApp.Infrastructure.Data;

namespace WorkoutApp.Infrastructure.Repositories;

public class EFCategortRepository : ICategoryRepository
{
    private readonly WorkoutDbContext _dbContext;
    public EFCategortRepository(WorkoutDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public Task<Category> GetByIdAsync(int id)
    {
       var category = _dbContext.Categories.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
         return category;
    }

    public Task<List<Category>> GetAllAsync()
    {
        return _dbContext.Categories.AsNoTracking().ToListAsync();
    }

    public List<Category> GetAll()
    {
        return _dbContext.Categories.AsNoTracking().ToList();
    }

    public async Task AddAsync(Category entity)
    {
         var addingCategory = await _dbContext.Categories.AddAsync(entity);
         await _dbContext.SaveChangesAsync();
     
    }

    public async Task UpdateAsync(Category entity)
    {
        var updatingCategory = _dbContext.Categories.Update(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Category entity)
    {
        var deletingCategory = await _dbContext.Categories.FindAsync(entity.Id);
        _dbContext.Categories.Remove(deletingCategory);
        await _dbContext.SaveChangesAsync();
    }
}