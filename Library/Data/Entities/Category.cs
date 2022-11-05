using Library.Constants;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.ComponentModel.DataAnnotations;

namespace Library.Data.Entities
{
    public class Category
    {
        public Category()
        {
            this.Books = new HashSet<Book>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(CategoryConstants.NameMaxLength)]
        public string Name { get; set; } = null!;

        public ICollection<Book> Books { get; set; }
    }
}