using AutoMapper;
using WorkoutApp.DataTransferObjects.Responses;
using WorkoutApp.Infrastructure.Repositories;

namespace WorkoutApp.Services;

public class CategoryService : ICategoryService
{
    private readonly IMapper _mapper;
    private readonly ICategoryRepository _categoryRepository;
    public CategoryService(IMapper mapper, ICategoryRepository categoryRepository)
    {
        _mapper = mapper;
        _categoryRepository = categoryRepository;
    }
    
    public IEnumerable<CategoryDisplayResponse> GetCategoryDisplayResponses()
    {
        var categories = _categoryRepository.GetAll();
        return _mapper.Map<IEnumerable<CategoryDisplayResponse>>(categories);
    }
}