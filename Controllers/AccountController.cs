using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MoneyTransferApplication.Models;
using MoneyTransferApplication.Services.Interface;
using MoneyTransferApplication.ViewModel.Authentication.User;
using MoneyTransferApplication.ViewModel.User;
using System.Threading.Tasks;

namespace MoneyTransferApplication.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly SignInManager<User> _signInManager;
     

        public AccountController(IUserService userService, SignInManager<User> signInManager  )
        {
            _userService = userService;
            _signInManager = signInManager;
       
        }
        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(User model, string password)
        {
            if (!ModelState.IsValid) return View(model);

            var result = await _userService.RegisterAsync(model, password);
            if (result.Succeeded) return RedirectToAction("Login");

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginUserVM model)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    Email = model.Email,
                    Password = model.Password 
                };
                var result = await _userService.CreateUserAsync(user);
                if (result.Success)
                {
                    return RedirectToAction("Login");
                }
                ModelState.AddModelError("", "Invalid login attempt");
            }
            return View(model);
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserVM model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.CreateUserAsync(model);
                if (result.Success)
                {
                    return RedirectToAction("Login");
                }
               
            }
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }

    }
}
