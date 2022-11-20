using eTickets.Data.Base;
using eTickets.Data.VeiwModels;
using eTickets.Data.ViewModels;
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

        public async Task<NewMovieDropdownsVM> GetNewMovieDropdownsValues()
        {
            var response = new NewMovieDropdownsVM();

            response.Actors = await _context.Actors.OrderBy(x => x.FullName).ToListAsync();
            response.Producers = await _context.Producers.OrderBy(x => x.FullName).ToListAsync();
            response.Cinemas = await _context.Cinemas.OrderBy(x => x.Name).ToListAsync();

            return response;
        }

        public async Task AddNewMovieAsync(NewMovieVM data)
        {
            Movie movie = new Movie()
            {
                Name = data.Name,
                Description = data.Description,
                ImageURL = data.ImageURL,
                CinemaId = data.CinemaId,
                StartDate = data.StartDate,
                EndDate = data.EndDate,
                Price = data.Price,
                MovieCategory = data.MovieCategory,
                ProducerId = data.ProducerId
            };

            await _context.AddAsync(movie);
            await _context.SaveChangesAsync();

            // Add Movie Actors
            foreach(Guid actorId in data.ActorIds)
            {
                ActorMovie actorMovie = new ActorMovie()
                {
                    MovieId = movie.Id,
                    ActorId = actorId
                };

                await _context.ActorMovies.AddAsync(actorMovie);
            }

            await _context.SaveChangesAsync();
        }

        public async Task UpdateMovieAsync(NewMovieVM data)
        {
            Movie movie = await _context.Movies.FirstOrDefaultAsync(x => x.Id == data.Id);

            if(movie != null)
            {
                movie.Name = data.Name;
                movie.Description = data.Description;
                movie.ImageURL = data.ImageURL;
                movie.CinemaId = data.CinemaId;
                movie.StartDate = data.StartDate;
                movie.EndDate = data.EndDate;
                movie.Price = data.Price;
                movie.MovieCategory = data.MovieCategory;
                movie.ProducerId = data.ProducerId;

                await _context.SaveChangesAsync();

                // Remove existing actors
                var existingActorsDb = _context.ActorMovies.Where(x => x.MovieId == data.Id).ToList();
                _context.ActorMovies.RemoveRange(existingActorsDb);
                await _context.SaveChangesAsync();

                // Add Movie Actors
                foreach (Guid actorId in data.ActorIds)
                {
                    ActorMovie actorMovie = new ActorMovie()
                    {
                        MovieId = data.Id,
                        ActorId = actorId
                    };

                    await _context.ActorMovies.AddAsync(actorMovie);
                }

                await _context.SaveChangesAsync();
            }
        }
    }
}
