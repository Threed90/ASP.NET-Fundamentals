using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Library.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if (User?.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction(
                    nameof(BooksController.All), 
                    nameof(BooksController).Replace("Controller", string.Empty));
            }
            return View();
        }
    }
}