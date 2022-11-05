using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace Watchlist.Data.Entities
{
    public class Movie
    {
        public Movie()
        {
            this.Users = new HashSet<User>();
        }
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(50)]
        public string Director { get; set; } = null!;

        [Required]
        [MaxLength(5000)]
        public string Description{ get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        public decimal Rating { get; set; }

        public int GenreId { get; set; }

        public Genre Genre { get; set; } = null!;

        public virtual ICollection<User> Users { get; set; }
    }
}