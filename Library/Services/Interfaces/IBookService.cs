using Library.Models.Book;

namespace Library.Services.Interfaces
{
    public interface IBookService
    {
        Task<List<BookViewModel>> GetAllAsync();
        Task<List<MineBookViewModel>> GetReadedBooks(string userId);
        Task AddBook(BookFormModel model);

        Task RemoveBook(int bookId, string userId);
        Task AddToReaded(int bookId, string userId);
    }
}
