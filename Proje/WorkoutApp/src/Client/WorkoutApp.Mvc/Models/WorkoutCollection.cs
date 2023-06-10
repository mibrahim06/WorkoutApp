using Microsoft.AspNetCore.Mvc;
using WorkoutApp.DataTransferObjects.Responses;

namespace WorkoutApp.Mvc.Models;

public class WorkoutCollection
{
    public List<WorkoutItem> Workouts { get; set; } = new();
    public void ClearAll() => Workouts.Clear();
    public int TotalWorkoutsCount => Workouts.Sum(i => i.Count);
    public void AddNewWorkout(WorkoutItem workoutItem)
    {
        var existingWorkout = Workouts.FirstOrDefault(c => c.Workout.Id == workoutItem.Workout.Id);
        if (existingWorkout != null)
        {
            existingWorkout.Count += workoutItem.Count;
        }
        else
        {
            Workouts.Add(workoutItem);
        }
    }
}

public class WorkoutItem
{
    public WorkoutItem(WorkoutDisplayResponse workout, int count)
    {
        Workout = workout;
        Count = count;
    }
    
    public WorkoutDisplayResponse Workout { get; set; }
    public int Count { get; set; }
}