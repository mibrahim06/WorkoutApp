using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using WorkoutApp.Mvc.Models;
using WorkoutApp.Services;

namespace WorkoutApp.Mvc.Controllers;

public class WorkoutPlanController : Controller
{
    private readonly IWorkoutService _workoutService;
    public WorkoutPlanController(IWorkoutService workoutService)
    {
        _workoutService = workoutService;
    }
    // GET 
    public IActionResult Index()
    {
        var workoutCollection = getWorkOutCollectionFromSession();
        return View(workoutCollection);
    }

    public IActionResult AddWorkout(int id)
    {
        // get workout from db
        var selectedWorkout = _workoutService.GetWorkoutDisplayResponseById(id);
        // create workout item
        var name = selectedWorkout.Name;
        var workoutItem = new WorkoutItem(selectedWorkout, 1);
        // add workout item to workout collection
        var workoutCollection = getWorkOutCollectionFromSession();
        workoutCollection.AddNewWorkout(workoutItem);
        // save workout collection to session
        saveToSession(workoutCollection);
        return Json(new { message = $"{name} başarıyla eklendi!"});
    }

    public IActionResult DeleteWorkout(int id)
    {
        // get selected workout from db
        var selectedWorkout = _workoutService.GetWorkoutDisplayResponseById(id);
        // delete workout from workout collection
        var workoutCollection = getWorkOutCollectionFromSession();
        workoutCollection.DeleteWorkout(id);
        // save workout collection to session
        saveToSession(workoutCollection);
        return Json(new { message = $"{selectedWorkout.Name} silindi!"});
    }

    private WorkoutCollection getWorkOutCollectionFromSession()
    {
        var serialized = HttpContext.Session.GetString("plan");
        if (serialized == null)
        {
            var workoutCollection = new WorkoutCollection();
            return workoutCollection;
        }
        var workout = JsonSerializer.Deserialize<WorkoutCollection>(serialized);
        return workout;
    }
    
    private void saveToSession(WorkoutCollection workoutCollection)
    {
        var serialized = JsonSerializer.Serialize<WorkoutCollection>(workoutCollection);
        if (!string.IsNullOrWhiteSpace(serialized))
        {
            HttpContext.Session.SetString("plan", serialized);
        }
    }
}