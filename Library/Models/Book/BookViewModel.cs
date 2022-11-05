using Library.Constants;
using Library.Models.Category;
using System.ComponentModel.DataAnnotations;

namespace Library.Models.Book
{
    public class BookViewModel
    {
        //no need validation - just get all from DB
        public int Id {get; set;}

        public string Title { get; set; } = null!;

        public string Author { get; set; } = null!;

        public string ImageUrl {get; set;} = null!;

        public decimal Rating {get; set;}

        public string Category {get; set;} = null!;

    }
}
