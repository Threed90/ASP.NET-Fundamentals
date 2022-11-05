using Watchlist.Models.Movies;

namespace Watchlist.Services.Interfaces
{
    public interface IMovieService
    {
        Task<List<MovieViewModel>> GetAll();
        Task<List<MovieViewModel>> GetWatched(string userId);
        Task AddMovie(MovieFormModel model);

        Task RemoveMovie(int movieId, string userId);
        Task AddToWatched(int movieId, string userId);
    }
}
