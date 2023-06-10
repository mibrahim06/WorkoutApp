using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WorkoutApp.Mvc.Models;
using WorkoutApp.Services;

namespace WorkoutApp.Mvc.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IWorkoutService _workoutService;
    public HomeController(ILogger<HomeController> logger, IWorkoutService workoutService)
    {
        _logger = logger;
        _workoutService = workoutService;
    }

    public IActionResult Index(int pageNo = 1, int? Id = null)
    {
        var workouts = _workoutService.GetWorkoutDisplayResponses();
        var workoutPerPage = 8;
        var totalWorkoutCount = workouts.Count();
        var pageCount = (int)Math.Ceiling((double)totalWorkoutCount / workoutPerPage);
        pageNo = pageNo > pageCount ? pageCount : pageNo;
        var pagingInfo = new PagingInfo
        {
            CurrentPage = pageNo,
            ItemsPerPage = workoutPerPage,
            TotalItems = totalWorkoutCount
        };
        Console.WriteLine("test");
        Console.WriteLine($"pageNo: {pageNo}, pageCount: {pageCount}");
        Console.WriteLine("Workout number: " + workouts.Count());
        var paginationWorkoutViewModel = new PaginationWorkoutViewModel
        {
            Workouts = workouts,
            PagingInfo = pagingInfo
        };
        return View(paginationWorkoutViewModel);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}