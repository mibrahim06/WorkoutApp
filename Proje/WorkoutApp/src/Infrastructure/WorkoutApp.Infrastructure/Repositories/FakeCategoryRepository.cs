using WorkoutApp.Entities;

namespace WorkoutApp.Infrastructure.Repositories;

/**
 * Fake repository for the Category entity for testing purposes
 * @Warning: This is not a real repository, it is only used for testing purposes
 */
public class FakeCategoryRepository : ICategoryRepository
{
    private readonly List<Category> _categories;

    public FakeCategoryRepository()
    {
        _categories = new()
        {
            new Category() { Id = 1, Name = "Category 1" },
            new Category() { Id = 2, Name = "Category 2" },
            new Category() { Id = 3, Name = "Category 3" },
        };
    }
    
    public Task<Category> GetByIdAsync(int id)
    {
       return Task.FromResult(_categories.FirstOrDefault(x => x.Id == id));
    }

    public Task<List<Category>> GetAllAsync()
    {
        return Task.FromResult(_categories);
    }

    public List<Category> GetAll()
    {
        return _categories;
    }

    public Task AddAsync(Category entity)
    {
        var category = _categories.FirstOrDefault(x => x.Id == entity.Id);
        if (category == null)
        {
            _categories.Add(entity);
        }
        return Task.FromResult(entity);
    }

    public Task UpdateAsync(Category entity)
    {
        var category = _categories.FirstOrDefault(x => x.Id == entity.Id);
        if (category != null)
        {
            category.Name = entity.Name;
        }
        return Task.FromResult(entity);
    }

    public Task DeleteAsync(Category entity)
    {
        var category = _categories.FirstOrDefault(x => x.Id == entity.Id);
        if (category != null)
        {
            _categories.Remove(category);
        }
        return Task.FromResult(entity);
    }
}