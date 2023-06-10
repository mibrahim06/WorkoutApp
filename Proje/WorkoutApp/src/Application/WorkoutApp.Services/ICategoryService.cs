using WorkoutApp.DataTransferObjects.Responses;

namespace WorkoutApp.Services;

public interface ICategoryService
{
    public IEnumerable<CategoryDisplayResponse> GetCategoryDisplayResponses();
}