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
    public async Task<IActionResult> Login(UserLoginViewModel userLogin, string? rtnUrl)
    {
        if (ModelState.IsValid)
        {
            var user = _userService.Authenticate(userLogin.Username, userLogin.Password);
            if (user != null)
            {
                Claim[] claims = new Claim[]
                {
                    new Claim(ClaimTypes.Name,user.Name),
                    new Claim(ClaimTypes.Email,user.Email),
                    new Claim(ClaimTypes.Role,user.Role)
                };
                ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(principal);

                if (!string.IsNullOrEmpty(rtnUrl) && Url.IsLocalUrl(rtnUrl))
                {
                    return Redirect(rtnUrl);
                }
                return Redirect("/");

            }
            ModelState.AddModelError("login", "Kullanıcı adı ya da şifre yanlış!");
        }

        return View();
    }
    
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }
    
    public IActionResult AccessDenied()
    {
        return View();
    }
}