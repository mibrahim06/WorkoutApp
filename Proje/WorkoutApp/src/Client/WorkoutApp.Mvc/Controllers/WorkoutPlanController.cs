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
        WorkoutCollection workoutCollection = getWorkOutCollectionFromSession();
        workoutCollection.AddNewWorkout(workoutItem);
        // save workout collection to session
        saveToSession(workoutCollection);
        return Json(new { message = $"{name} başarıyla eklendi!"});
    }

    private void saveToSession(WorkoutCollection workoutCollection)
    {
        var serialized = JsonSerializer.Serialize<WorkoutCollection>(workoutCollection);
        HttpContext.Session.SetString("plan", serialized);
    }

    private WorkoutCollection getWorkOutCollectionFromSession()
    {
        var serializedString = HttpContext.Session.GetString("plan"); 
        // if first time, create new collection and return
        if(serializedString == null)
        {
            return new WorkoutCollection();
        } 
        // if not first time, get current collection from session and return
        var currentColletion = JsonSerializer.Deserialize<WorkoutCollection>(serializedString);
        return currentColletion;
    }
}