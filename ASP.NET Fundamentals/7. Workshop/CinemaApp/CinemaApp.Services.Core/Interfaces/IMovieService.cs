using CinemaApp.Web.ViewModels.Movie;

namespace CinemaApp.Services.Core.Interfaces
{
    public interface IMovieService
    {
        Task<IEnumerable<AllMoviesIndexViewModel>> GetAllMoviesAsync();

        Task AddMovieAsync(MovieFormInputModel inputModel);

        Task<MovieDetailsViewModel?> GetMovieDetailsByIdAsync(string? id);

        Task<MovieFormInputModel?> GetEditableMovieByIdAsync(string? id);

        Task<bool> EditMovieAsync(MovieFormInputModel inputModel);
    }
}
