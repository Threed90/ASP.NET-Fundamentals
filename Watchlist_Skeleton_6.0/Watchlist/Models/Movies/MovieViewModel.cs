using System.ComponentModel.DataAnnotations;
using Watchlist.Data.Entities;
using Watchlist.Models.Genres;

namespace Watchlist.Models.Movies
{
    public class MovieViewModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(50)]
        public string Title { get; set; } = null!;

        [Required]
        [MinLength(5)]
        [MaxLength(50)]
        public string Director { get; set; } = null!;

        [Required]
        [MinLength(5)]
        [MaxLength(5000)]
        public string Description { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [Range(typeof(decimal), "0.00", "10.00")]
        public decimal Rating { get; set; }

        [Required]
        public GenreViewModel Genre { get; set; } = null!;

    }
}
