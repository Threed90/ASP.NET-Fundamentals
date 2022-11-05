using Microsoft.EntityFrameworkCore;
using Watchlist.Data;
using Watchlist.Models.Genres;
using Watchlist.Models.Movies;
using Watchlist.Services.Interfaces;
using System.Linq;
using Watchlist.Data.Entities;

namespace Watchlist.Services
{
    public class MovieService : IMovieService
    {
        private readonly WatchlistDbContext data;
        public MovieService(WatchlistDbContext data)
        {
            this.data = data;
        }

        public async Task AddMovie(MovieFormModel model)
        {
            var movie = new Movie()
            {
                GenreId = model.GenreId,
                Title = model.Title,
                Description = model.Description,
                Director = model.Director,
                ImageUrl = model.ImageUrl,
                Rating = model.Rating,
            };
            data.Movies.Add(movie);
            await data.SaveChangesAsync();
        }

        public async Task AddToWatched(int movieId, string userId)
        {
            var user = await this.data
                .Users
                .Include(u => u.WatchedMovies)
                .FirstOrDefaultAsync(u => u.Id == userId);

            var movie = await this.data.Movies
                .FindAsync(movieId);

            movie.Users.Add(user);
            await this.data.SaveChangesAsync();
        }

        public async Task<List<MovieViewModel>> GetAll()
        {
            var movies = await this.data.Movies
                .Select(m => new MovieViewModel()
                {
                    Id = m.Id,
                    Title = m.Title,
                    Description = m.Description,
                    Director = m.Director,
                    Genre = new GenreViewModel()
                    {
                        Id = m.Genre.Id,
                        Name = m.Genre.Name,
                    },
                    ImageUrl = m.ImageUrl,
                    Rating = m.Rating
                })
                .ToListAsync();

            return movies;
        }

        public async Task<List<MovieViewModel>> GetWatched(string userId)
        {
            var user = await this.data
                .Users
                .Include (u => u.WatchedMovies)
                .ThenInclude(m => m.Genre)
                .FirstOrDefaultAsync(u => u.Id == userId);

            if(user == null)
            {
                return new List<MovieViewModel>();
            }

            var movies = user
                .WatchedMovies
                .Select(m => new MovieViewModel()
                {
                    Id = m.Id,
                    Description = m.Description,
                    Director = m.Director,
                    Genre = new GenreViewModel()
                    {
                        Id = m.GenreId,
                        Name = m.Genre.Name
                    },
                    ImageUrl = m.ImageUrl,
                    Rating = m.Rating,
                    Title = m.Title
                })
                .ToList();

            return movies;
        }

        public async Task RemoveMovie(int movieId, string userId)
        {
            var user = await this.data
                .Users
                .Include(u => u.WatchedMovies)
                .FirstOrDefaultAsync(u => u.Id == userId);

            var movie = await this.data.Movies
                .FindAsync(movieId);

            movie.Users.Remove(user);
            await this.data.SaveChangesAsync();
        }
    }
}
