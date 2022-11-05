using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Watchlist.Models.Movies;
using Watchlist.Services.Interfaces;

namespace Watchlist.Controllers
{
    public class MoviesController : Controller
    {
        private IMovieService movieService;
        private IGenreService genreService;
        //private UserManager<User> userManager;
        public MoviesController(
            IMovieService movieService,
            IGenreService genreService
            /*UserManager<User> userManager*/)
        {
            this.movieService = movieService;
            this.genreService = genreService;
            //this.userManager = userManager;
        }

        public async Task<IActionResult> All()
        {
            var movies = await movieService.GetAll();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var watched = await this.movieService.GetWatched(userId);

            var model = new DoubleMovieListViewModel()
            {
                Movies = movies,
                WatchedMovies = watched
            };

            return View(model);
        }

        public IActionResult Add()
        {
            var genres = genreService.GetAll();

            return View(new MovieFormModel()
            {
                Genres = genres
            });
        }

        [HttpPost]
        public async Task<IActionResult> Add(MovieFormModel model)
        {
            await movieService.AddMovie(model);

            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> AddToCollection(int movieId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await movieService.AddToWatched(movieId, userId);
            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCollection(int movieId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await movieService.RemoveMovie(movieId, userId);
            return RedirectToAction(nameof(Watched));
        }

        public async Task<IActionResult> Watched()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var movies = await this.movieService.GetWatched(userId);
            return View(movies);
        }
    }
}
