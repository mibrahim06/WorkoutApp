using Microsoft.AspNetCore.Mvc;

namespace WorkoutApp.Mvc.Controllers;

public class WorkoutPlanController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult AddWorkout(int id)
    {
        return Json(new { message = $"{id}'li workout eklendi" });
    }
}