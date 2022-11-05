
using Library.Controllers;
using Library.Data.Entities;
using Library.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class UserController : Controller
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;

        public UserController(
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            if (User?.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction(nameof(BooksController.All), nameof(BooksController).Replace("Controller", string.Empty));
            }
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
            var result = await signInManager.PasswordSignInAsync(user, model.Password, true, false);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Unable to log in!");
                return View(model);
            }

            return RedirectToAction(nameof(BooksController.All), nameof(BooksController).Replace("Controller", string.Empty));
        }

        [AllowAnonymous]
        public IActionResult Register()
        {
            if (User?.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction(nameof(BooksController.All), nameof(BooksController).Replace("Controller", string.Empty));
            }

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

            var user = new ApplicationUser()
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

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();


            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).Replace("Controller", string.Empty));
        }
    }
}
