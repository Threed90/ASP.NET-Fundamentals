using System.ComponentModel.DataAnnotations;

namespace Watchlist.Models.User
{
    public class RegisterModel
    {
        [Required]
        [MinLength(5)]
        [MaxLength(20)]
        public string UserName { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(60)]
        public string Email { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(20)]
        [Compare(nameof(ConfirmPassword))]
        public string Password { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(20)]
        public string ConfirmPassword { get; set; }

    }
}
