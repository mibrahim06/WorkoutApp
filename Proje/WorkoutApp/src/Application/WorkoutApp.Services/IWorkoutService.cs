using WorkoutApp.DataTransferObjects.Responses;

namespace WorkoutApp.Services;

public interface IWorkoutService
{
    public IEnumerable<WorkoutDisplayResponse> GetWorkoutDisplayResponses();
}