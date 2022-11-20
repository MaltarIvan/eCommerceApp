using eTickets.Data.Base;
using eTickets.Models;

namespace eTickets.Data.Services.Movies
{
    public class MoviesService : EntityBaseRepository<Movie>, IMoviesService
    {
        public MoviesService(AppDbContext context) : base(context)
        {
        }
    }
}
