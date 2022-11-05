using Library.Data;
using Library.Data.Entities;
using Library.Models.Book;
using Microsoft.EntityFrameworkCore;
using Library.Services.Interfaces;

namespace Library.Services
{
    public class BookService : IBookService
    {
        private readonly LibraryDbContext data;
        public BookService(LibraryDbContext data)
        {
            this.data = data;
        }

        public async Task AddBook(BookFormModel model)
        {
            var book = new Book()
            {
                Title = model.Title,
                Author = model.Author,
                CategoryId = model.CategoryId,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                Rating = model.Rating
            };
            data.Books.Add(book);
            await data.SaveChangesAsync();
        }

        public async Task AddToReaded(int bookId, string userId)
        {
            var user = await this.data
                .Users
                .Include(u => u.Books)
                .FirstOrDefaultAsync(u => u.Id == userId);

            var book = await this.data.Books
                .FindAsync(bookId);

            book.Users.Add(user);
            await this.data.SaveChangesAsync();
        }

        public async Task<List<BookViewModel>> GetAllAsync()
        {
            var books = await this.data.Books
                .Select(b => new BookViewModel()
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    ImageUrl = b.ImageUrl,
                    Rating = b.Rating,
                    Category = b.Category.Name
                })
                .ToListAsync();

            return books;
        }

        public async Task<List<MineBookViewModel>> GetReadedBooks(string userId)
        {
            var user = await this.data
                .Users
                .Include (u => u.Books)
                .ThenInclude(b => b.Category)
                .FirstOrDefaultAsync(u => u.Id == userId);

            if(user == null)
            {
                return new List<MineBookViewModel>();
            }

            var books = user
                .Books
                .Select(b => new MineBookViewModel()
                {
                    Id=b.Id,
                    Title = b.Title,
                    Description = b.Description,
                    Author = b.Author,
                    ImageUrl = b.ImageUrl,
                    Category = b.Category.Name,
                    Rating = b.Rating,
                })
                .ToList();

            return books;
        }

        public async Task RemoveBook(int bookId, string userId)
        {
            var user = await this.data
                .Users
                .Include(u => u.Books)
                .FirstOrDefaultAsync(u => u.Id == userId);

            var book = await this.data.Books
                .FindAsync(bookId);

            book.Users.Remove(user);
            await this.data.SaveChangesAsync();
        }
    }
}
