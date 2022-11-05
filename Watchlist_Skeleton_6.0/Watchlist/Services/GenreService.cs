using Microsoft.EntityFrameworkCore;
using Watchlist.Data;
using Watchlist.Models.Genres;
using Watchlist.Services.Interfaces;

namespace Watchlist.Services
{
    public class GenreService : IGenreService
    {
        private readonly WatchlistDbContext data;
        public GenreService(WatchlistDbContext data)
        {
            this.data = data;
        }
        public List<GenreViewModel> GetAll()
        {
            return this.data.Genres
                .AsNoTracking()
                .Select(g => new GenreViewModel()
                {
                    Id = g.Id,
                    Name = g.Name,
                })
                .ToList();
        }
    }
}
