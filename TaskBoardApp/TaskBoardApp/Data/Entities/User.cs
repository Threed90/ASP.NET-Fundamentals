namespace TaskBoardApp.Data.Entities
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;

    using static Constants.DataConstants.User;
    public class User : IdentityUser
    {
        [Required]
        [MaxLength(MaxUserFirstName)]
        public string FirstName { get; init; }

        [Required]
        [MaxLength(MaxUserLastName)]
        public string LastName { get; init; }
    }
}
