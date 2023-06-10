using WorkoutApp.DataTransferObjects.Responses;

namespace WorkoutApp.Mvc.Models;

public class WorkoutCollection
{
    public List<WorkoutItem> Workouts { get; set; } = new();
    public void ClearAll() => Workouts.Clear();
}

public class WorkoutItem
{
    public WorkoutItem(WorkoutDisplayResponse workout)
    {
        Id = workout.Id;
        Name = workout.Name;
        Description = workout.Description;
    }
    
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
}