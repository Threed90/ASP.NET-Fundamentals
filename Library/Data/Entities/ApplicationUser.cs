using Library.Constants;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Eventing.Reader;

namespace Library.Data.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            this.Books = new HashSet<Book>(); 
        }

        [Required]
        [MaxLength(UserConstants.UserNameMaxLength)]
        public override string UserName 
        { 
            get => base.UserName; 
            set => base.UserName = value; 
        }

        [Required]
        [MaxLength(UserConstants.EmailMaxLength)]
        public override string Email 
        { 
            get => base.Email; 
            set => base.Email = value; 
        }


        public ICollection<Book> Books { get; set; }
    }
}
