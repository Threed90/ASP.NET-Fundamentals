using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace Watchlist.Data.Entities
{
    public class User : IdentityUser
    {
        public override string UserName { get; set; }
        public User()
        {
            this.WatchedMovies = new HashSet<Movie>();
            
        }

        public virtual ICollection<Movie> WatchedMovies { get; set; }
    }
}

//User	
//•	Has an Id – a string, Primary Key
//•	Has a Username – a string with min length 5 and max length 20 (required)
//•	Has an Email – a string with min length 10 and max length 60 (required)
//•	Has a Password – a string with min length 5 and max length 20 (before hashed) – no max length required for a hashed password in the database (required)
//•	Has WatchedMovies – a collection of Movies
