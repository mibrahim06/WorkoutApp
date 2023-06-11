using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using WorkoutApp.Mvc.Models;
using WorkoutApp.Services;

namespace WorkoutApp.Mvc.Controllers;

public class UserController : Controller
{
    private readonly IUserService _userService;
    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    // GET
    public IActionResult Index()
    {
        return View();
    }
    
    public IActionResult Login(string? rtnUrl)
    {
        ViewBag.ReturnUrl = rtnUrl;
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Login(UserLoginViewModel userLoginViewModel, string? rtnUrl)
    {
        if (!ModelState.IsValid)
        {
            var user = _userService.Authenticate(userLoginViewModel.Username, userLoginViewModel.Password);
            if (user == null)
            {
                ModelState.AddModelError("", "Kullanıcı adı veya şifre yanlış");
                return View(userLoginViewModel);
            }
            Claim[] claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Role, user.Role)
            };
            ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            await HttpContext.SignInAsync(claimsPrincipal);
            
            if (!string.IsNullOrEmpty(rtnUrl) && Url.IsLocalUrl(rtnUrl))
            {
                return Redirect(rtnUrl);
            }
            return RedirectToAction("Index", "Home");
        }
        return View(userLoginViewModel);
    }
    
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }
}