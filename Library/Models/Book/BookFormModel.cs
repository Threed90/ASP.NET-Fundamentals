using Library.Constants;
using Library.Models.Category;
using System.ComponentModel.DataAnnotations;

namespace Library.Models.Book
{
    public class BookFormModel
    {
        [Required]
        [MinLength(BookConstants.TitleMinLength)]
        [MaxLength(BookConstants.TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [MinLength(BookConstants.AuthorMinLength)]
        [MaxLength(BookConstants.AuthorMaxLength)]
        public string Author { get; set; } = null!;
        [Required]
        [MinLength(BookConstants.DescriptionMinLength)]
        [MaxLength(BookConstants.DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        [Url]// maybe
        public string ImageUrl { get; set; } = null!;

        [Required]
        [Range(typeof(decimal), BookConstants.RatingMinRange, BookConstants.RatingMaxLength)]
        public decimal Rating { get; set; }

        [Required]
        public int CategoryId { get; set; }

        
        public List<CategoryViewModel>? Categories { get; set; }

    }
}
