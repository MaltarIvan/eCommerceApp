using eTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActorMovie>().HasKey(x => new
            {
                x.ActorId,
                x.MovieId
            });

            modelBuilder.Entity<ActorMovie>().HasOne(x => x.Movie).WithMany(x => x.ActorMovieList).HasForeignKey(x => x.MovieId);
            modelBuilder.Entity<ActorMovie>().HasOne(x => x.Actor).WithMany(x => x.ActorMovieList).HasForeignKey(x => x.ActorId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<ActorMovie> ActorMovies { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Producer> Producers { get; set; }
    }
}
