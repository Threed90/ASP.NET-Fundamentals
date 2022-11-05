using Library.Constants;
using System.ComponentModel.DataAnnotations;

namespace Library.Models.Category
{
    public class CategoryViewModel
    {
       
        public int Id { get; set; }

        [Required]
        [MinLength(CategoryConstants.NameMinLength)]
        [MaxLength(CategoryConstants.NameMaxLength)]
        public string Name { get; set; } = null!;
    }
}
