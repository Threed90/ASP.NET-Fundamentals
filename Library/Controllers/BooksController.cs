using Library.Models.Book;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Library.Services.Interfaces;
using System.Security.Claims;
using Microsoft.Extensions.FileSystemGlobbing;

namespace Library.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookService bookService;
        private readonly ICategoryService categoryService;
        public BooksController(
            IBookService bookService,
            ICategoryService categoryService)
        {
            this.bookService = bookService;
            this.categoryService = categoryService;
        }

        [Authorize]
        public async Task<IActionResult> All()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var books = await this.bookService.GetAllAsync();
            var readedBooks = await this.bookService.GetReadedBooks(userId);
            return View(new ReadedAndUnreadedBookViewModel()
            {
                AllBooks = books,
                ReadedBooks = readedBooks
            });
        }

        [Authorize]
        public async Task<IActionResult> Add()
        {
            var categories = await this.categoryService.GetAllAsync();
            var model = new BookFormModel()
            {
                Categories = categories
            };

            return View(model);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add(BookFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await this.bookService.AddBook(model);
                return RedirectToAction(nameof(All));
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "An error occurred during new book adding! Please try again");
                return View(model);
            }
            

            
        }

        public async Task<IActionResult> Mine()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var books = await this.bookService.GetReadedBooks(userId);
            return View(books);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCollection(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await bookService.AddToReaded(id, userId);
            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCollection(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await bookService.RemoveBook(id, userId);
            return RedirectToAction(nameof(Mine));
        }
    }
}
