using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WorkoutApp.DataTransferObjects.Requests;
using WorkoutApp.Services;

namespace WorkoutApp.Mvc.Controllers;

[Authorize(Roles = "Admin, Editor")]
public class WorkoutController : Controller
{
    private readonly IWorkoutService _workoutService;
    private readonly ICategoryService _categoryService;
    public WorkoutController(IWorkoutService workoutService, ICategoryService categoryService)
    {
        _workoutService = workoutService;
        _categoryService = categoryService;
    }
    // GET
    public IActionResult Index()
    {
        var workouts = _workoutService.GetWorkoutDisplayResponses();
        return View(workouts);
    }
    

    public async Task<IActionResult> Create()
    { 
        ViewBag.Categories = getCategoriesForSelectList();
        return  View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(CreateNewWorkoutRequest request)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Categories = getCategoriesForSelectList();
            return View(request);
        }
        await _workoutService.CreateWorkoutAsync(request);
        return RedirectToAction("Index");
    }

    private IEnumerable<SelectListItem> getCategoriesForSelectList()
    {
        var categories = _categoryService.GetCategoryDisplayResponses();
        var selectLists = categories.Select(c => new SelectListItem(c.Name, c.Id.ToString()));
        return selectLists;
    }

    public IActionResult Edit()
    {
        return View();
    }

    public IActionResult Delete()
    {
        throw new NotImplementedException();
    }
}