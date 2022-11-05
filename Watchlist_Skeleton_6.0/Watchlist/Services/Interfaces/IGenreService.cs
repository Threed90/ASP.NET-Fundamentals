using Watchlist.Models.Genres;

namespace Watchlist.Services.Interfaces
{
    public interface IGenreService
    {
        List<GenreViewModel> GetAll();
    }
}
