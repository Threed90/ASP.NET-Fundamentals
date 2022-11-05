namespace Library.Models.Book
{
    public class ReadedAndUnreadedBookViewModel
    {
        public List<BookViewModel> AllBooks { get; set; } = null!;

        public List<MineBookViewModel> ReadedBooks { get; set; } = null!;
    }
}
