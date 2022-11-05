using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Watchlist.Models.User
{
    public class LoginModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; } 
    }
}
