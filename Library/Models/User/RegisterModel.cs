using Library.Constants;
using System.ComponentModel.DataAnnotations;

namespace Library.Models.User
{
    public class RegisterModel
    {
        [Required]
        [MinLength(UserConstants.UserNameMinLength)]
        [MaxLength(UserConstants.UserNameMaxLength)]
        public string UserName { get; set; } = null!;

        [Required]
        [MinLength(UserConstants.EmailMinLength)]
        [MaxLength(UserConstants.EmailMaxLength)]
        public string Email { get; set; } = null!;

        [Required]
        [MinLength(UserConstants.PasswordMinLength)]
        [MaxLength(UserConstants.PasswordMaxLength)]
        [DataType(DataType.Password)]
        
        public string Password { get; set; } = null!;

        [Required]
        [MinLength(UserConstants.PasswordMinLength)]
        [MaxLength(UserConstants.PasswordMaxLength)]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; } = null!;

    }
}
