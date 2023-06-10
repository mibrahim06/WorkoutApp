using Microsoft.AspNetCore.Mvc;
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
        return View();
    }

    public IActionResult AddWorkout(int id)
    {
        var selectedWorkout = _workoutService.GetWorkoutDisplayResponseById(id);
        var name = selectedWorkout.Name;
        return Json(new { message = $"{name} başarıyla eklendi!"});
    }
}