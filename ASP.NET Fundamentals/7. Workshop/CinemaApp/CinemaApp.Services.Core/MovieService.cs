using CinemaApp.Data;
using CinemaApp.Data.Models;
using CinemaApp.GCommon;
using CinemaApp.Services.Core.Interfaces;
using CinemaApp.Web.ViewModels.Movie;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using static CinemaApp.GCommon.ApplicationConstants;

namespace CinemaApp.Services.Core
{
    public class MovieService : IMovieService
    {
        private readonly CinemaAppDbContext dbContext;

        // When a service is being instantiated, ASP.NET will
        // provide an injected value for the DbContext
        public MovieService(CinemaAppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<AllMoviesIndexViewModel>> GetAllMoviesAsync()
        {
            IEnumerable<AllMoviesIndexViewModel> allMovies = await this.dbContext
                .Movies
                .AsNoTracking()
                .Select(m => new AllMoviesIndexViewModel
                {
                    Id = m.Id.ToString(),
                    Title = m.Title,
                    Genre = m.Genre,
                    ReleaseDate = m.ReleaseDate.ToString(AppDateFormat),
                    Director = m.Director,
                    ImageUrl = m.ImageUrl
                })
                .ToListAsync();

            foreach (AllMoviesIndexViewModel movie in allMovies)
            {
                if (string.IsNullOrEmpty(movie.ImageUrl))
                {
                    movie.ImageUrl = $"/images/{NoImageUrl}";
                }
            }

            return allMovies;
        }

        public async Task AddMovieAsync(MovieFormInputModel inputModel)
        {
            Movie newMovie = new Movie
            {
                Title = inputModel.Title,
                Genre = inputModel.Genre,
                Director = inputModel.Director,
                Description = inputModel.Description,
                Duration = inputModel.Duration,
                ImageUrl = inputModel.ImageUrl,
                ReleaseDate = DateOnly
                    .ParseExact(inputModel.ReleaseDate, AppDateFormat,
                    CultureInfo.InvariantCulture, DateTimeStyles.None)
            };

            await this.dbContext.Movies.AddAsync(newMovie);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<MovieDetailsViewModel?> GetMovieDetailsByIdAsync(string? id)
        {
            MovieDetailsViewModel? movieDetails = null;
            bool isIdValidGuid = Guid.TryParse(id, out Guid movieId);

            if (isIdValidGuid)
            {
                movieDetails = await this.dbContext
                    .Movies
                    .AsNoTracking()
                    .Where(m => m.Id == movieId)
                    .Select(m => new MovieDetailsViewModel
                    {
                        Id = m.Id.ToString(),
                        Title = m.Title,
                        Description = m.Description,
                        Duration = m.Duration,
                        Genre = m.Genre,
                        Director = m.Director,
                        ImageUrl = m.ImageUrl ?? $"/images/{NoImageUrl}",
                        ReleaseDate = m.ReleaseDate.ToString(AppDateFormat)
                    })
                    .SingleOrDefaultAsync();
            }

            return movieDetails;
        }

        public async Task<MovieFormInputModel?> GetEditableMovieByIdAsync(string? id)
        {
            MovieFormInputModel? editableMovie = null;
            bool isIdValidGuid = Guid.TryParse(id, out Guid movieId);

            if (isIdValidGuid)
            {
                editableMovie = await this.dbContext
                    .Movies
                    .AsNoTracking()
                    .Where(m => m.Id == movieId)
                    .Select(m => new MovieFormInputModel
                    {
                        // Id = m.Id.ToString(),
                        Title = m.Title,
                        Description = m.Description,
                        Duration = m.Duration,
                        Genre = m.Genre,
                        Director = m.Director,
                        ImageUrl = m.ImageUrl ?? $"/images/{NoImageUrl}",
                        ReleaseDate = m.ReleaseDate.ToString(AppDateFormat)
                    })
                    .SingleOrDefaultAsync();
            }

            return editableMovie;
        }

        public async Task<bool> EditMovieAsync(MovieFormInputModel inputModel)
        {
            Movie? editableMovie = await this.dbContext
                .Movies
                .SingleOrDefaultAsync(m => m.Id.ToString() == inputModel.Id);

            if (editableMovie == null)
            {
                return false;
            }

            DateOnly movieReleaseDate = DateOnly
                    .ParseExact(inputModel.ReleaseDate, AppDateFormat,
                    CultureInfo.InvariantCulture, DateTimeStyles.None);

            editableMovie.Title = inputModel.Title;
            editableMovie.Description = inputModel.Description;
            editableMovie.Director = inputModel.Director;
            editableMovie.Duration = inputModel.Duration;
            editableMovie.Genre = inputModel.Genre;
            editableMovie.ImageUrl = inputModel.ImageUrl ?? $"/images/{NoImageUrl}";
            editableMovie.ReleaseDate = movieReleaseDate;

            await this.dbContext.SaveChangesAsync();
            return true;
        }
    }
}
