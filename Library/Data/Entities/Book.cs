using Library.Constants;
using System.ComponentModel.DataAnnotations;

namespace Library.Data.Entities
{
    public class Book
    {
        public Book()
        {
            this.Users = new HashSet<ApplicationUser>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(BookConstants.TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(BookConstants.AuthorMaxLength)]
        public string Author { get; set; } = null!;

        [Required]
        [MaxLength(BookConstants.DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        public decimal Rating { get; set; }


        public int CategoryId { get; set; }

        public Category Category { get; set; } = null!;

        public ICollection<ApplicationUser> Users { get; set; }
    }
}