using WorkoutApp.DataTransferObjects.Requests;
using WorkoutApp.DataTransferObjects.Responses;

namespace WorkoutApp.Services;

public interface IWorkoutService
{
    public IEnumerable<WorkoutDisplayResponse> GetWorkoutDisplayResponses();
    public IEnumerable<WorkoutDisplayResponse> GetWorkoutDisplayResponsesByCategoryId(int categoryId);
    public WorkoutDisplayResponse GetWorkoutDisplayResponseById(int id);
    public Task CreateWorkoutAsync(CreateNewWorkoutRequest request);
    public Task DeleteWorkoutAsync(int id);
}