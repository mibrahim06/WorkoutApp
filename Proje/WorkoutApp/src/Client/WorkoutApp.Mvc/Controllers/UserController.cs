using Microsoft.AspNetCore.Mvc;
using WorkoutApp.Mvc.Models;

namespace WorkoutApp.Mvc.Controllers;

public class UserController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
    
    public IActionResult Login()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Login(UserLoginViewModel userLoginViewModel)
    {
        return View(userLoginViewModel);
    }
}