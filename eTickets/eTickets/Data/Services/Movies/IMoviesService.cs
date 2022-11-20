using eTickets.Data.Base;
using eTickets.Data.VeiwModels;
using eTickets.Data.ViewModels;
using eTickets.Models;

namespace eTickets.Data.Services.Movies
{
    public interface IMoviesService : IEntityBaseRepository<Movie>
    {
        Task<Movie> GetMovieByIdAsync(Guid id);
        Task<NewMovieDropdownsVM> GetNewMovieDropdownsValues();
        Task AddNewMovieAsync(NewMovieVM newMovieVM);
        Task UpdateMovieAsync(NewMovieVM newMovieVM);
    }
}
