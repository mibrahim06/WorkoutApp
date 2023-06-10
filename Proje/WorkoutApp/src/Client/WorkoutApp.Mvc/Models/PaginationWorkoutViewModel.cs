using WorkoutApp.DataTransferObjects.Responses;

namespace WorkoutApp.Mvc.Models;

public class PaginationWorkoutViewModel
{
    public IEnumerable<WorkoutDisplayResponse> Workouts { get; set; }
    public PagingInfo PagingInfo { get; set; }

}