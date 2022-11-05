
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Watchlist.Data.Entities;
using Watchlist.Models.User;

namespace Watchlist.Controllers
{
    public class UserController : Controller
    {
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;

        public UserController(
            SignInManager<User> signInManager,
            UserManager<User> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }
        public IActionResult Login()
        {
            var model = new LoginModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await userManager.FindByNameAsync(model.UserName);
            if (user == null)
            {
                return RedirectToAction(nameof(this.Register));
            }
            var result = await signInManager.PasswordSignInAsync(user, model.Password, false, false);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Unable to log in!");
                return View(model);
            }

            return RedirectToAction(nameof(MoviesController.All), nameof(MoviesController).Replace("Controller", string.Empty));
        }

        public IActionResult Register()
        {
            var model = new RegisterModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new User()
            {
                UserName = model.UserName,
                Email = model.Email,
            };

            var result = await userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                return RedirectToAction(nameof(this.Login));
            }

            ModelState.AddModelError("", "Unable to register! Follow the requests for registrations.");

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();


            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).Replace("Controller", string.Empty));
        }
    }
}
