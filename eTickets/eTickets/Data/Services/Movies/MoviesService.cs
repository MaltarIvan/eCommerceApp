using eTickets.Data.Base;
using eTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data.Services.Movies
{
    public class MoviesService : EntityBaseRepository<Movie>, IMoviesService
    {
        private readonly AppDbContext _context;

        public MoviesService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Movie> GetMovieByIdAsync(Guid id)
        {
            Movie movie = await _context.Movies.Include(c => c.Cinema).Include(p => p.Producer).Include(am => am.ActorMovieList).ThenInclude(A => A.Actor).FirstOrDefaultAsync(x => x.Id == id);

            return movie;
        }
    }
}
