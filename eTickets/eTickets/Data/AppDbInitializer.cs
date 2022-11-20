using eTickets.Data.Enums;
using eTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using(var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                Cinema cinema1 = new Cinema()
                {
                    Id = Guid.NewGuid(),
                    Name = "Cinema 1",
                    LogoPictureURL = "http://dotnethow.net/images/cinemas/cinema-1.jpeg",
                    Description = "This is the description of the first cinema"
                };

                Cinema cinema2 = new Cinema()
                {
                    Id = Guid.NewGuid(),
                    Name = "Cinema 2",
                    LogoPictureURL = "http://dotnethow.net/images/cinemas/cinema-2.jpeg",
                    Description = "This is the description of the first cinema"
                };

                Cinema cinema3 = new Cinema()
                {
                    Id = Guid.NewGuid(),
                    Name = "Cinema 3",
                    LogoPictureURL = "http://dotnethow.net/images/cinemas/cinema-3.jpeg",
                    Description = "This is the description of the first cinema"
                };

                Cinema cinema4 = new Cinema()
                {
                    Id = Guid.NewGuid(),
                    Name = "Cinema 4",
                    LogoPictureURL = "http://dotnethow.net/images/cinemas/cinema-4.jpeg",
                    Description = "This is the description of the first cinema"
                };

                Cinema cinema5 = new Cinema()
                {
                    Id = Guid.NewGuid(),
                    Name = "Cinema 5",
                    LogoPictureURL = "http://dotnethow.net/images/cinemas/cinema-5.jpeg",
                    Description = "This is the description of the first cinema"
                };

                Producer producer1 = new Producer()
                {
                    Id = Guid.NewGuid(),
                    FullName = "Producer 1",
                    Bio = "This is the Bio of the first actor",
                    ProfilePictureURL = "http://dotnethow.net/images/producers/producer-1.jpeg"
                };

                Producer producer2 = new Producer()
                {
                    Id = Guid.NewGuid(),
                    FullName = "Producer 2",
                    Bio = "This is the Bio of the second actor",
                    ProfilePictureURL = "http://dotnethow.net/images/producers/producer-2.jpeg"
                };

                Producer producer3 = new Producer()
                {
                    Id = Guid.NewGuid(),
                    FullName = "Producer 3",
                    Bio = "This is the Bio of the second actor",
                    ProfilePictureURL = "http://dotnethow.net/images/producers/producer-3.jpeg"
                };

                Producer producer4 = new Producer()
                {
                    Id = Guid.NewGuid(),
                    FullName = "Producer 4",
                    Bio = "This is the Bio of the second actor",
                    ProfilePictureURL = "http://dotnethow.net/images/producers/producer-4.jpeg"
                };

                Producer producer5 = new Producer()
                {
                    Id = Guid.NewGuid(),
                    FullName = "Producer 5",
                    Bio = "This is the Bio of the second actor",
                    ProfilePictureURL = "http://dotnethow.net/images/producers/producer-5.jpeg"
                };

                Actor actor1 = new Actor()
                {
                    Id = Guid.NewGuid(),
                    FullName = "Actor 1",
                    Bio = "This is the Bio of the first actor",
                    ProfilePictureURL = "http://dotnethow.net/images/actors/actor-1.jpeg"

                };

                Actor actor2 = new Actor()
                {
                    Id = Guid.NewGuid(),
                    FullName = "Actor 2",
                    Bio = "This is the Bio of the second actor",
                    ProfilePictureURL = "http://dotnethow.net/images/actors/actor-2.jpeg"
                };

                Actor actor3 = new Actor()
                {
                    Id = Guid.NewGuid(),
                    FullName = "Actor 3",
                    Bio = "This is the Bio of the second actor",
                    ProfilePictureURL = "http://dotnethow.net/images/actors/actor-3.jpeg"
                };

                Actor actor4 = new Actor()
                {
                    Id = Guid.NewGuid(),
                    FullName = "Actor 4",
                    Bio = "This is the Bio of the second actor",
                    ProfilePictureURL = "http://dotnethow.net/images/actors/actor-4.jpeg"
                };

                Actor actor5 = new Actor()
                {
                    Id = Guid.NewGuid(),
                    FullName = "Actor 5",
                    Bio = "This is the Bio of the second actor",
                    ProfilePictureURL = "http://dotnethow.net/images/actors/actor-5.jpeg"
                };

                Movie movie1 = new Movie()
                {
                    Id = Guid.NewGuid(),
                    Name = "Life",
                    Description = "This is the Life movie description",
                    Price = 39.50,
                    ImageURL = "http://dotnethow.net/images/movies/movie-3.jpeg",
                    StartDate = DateTime.Now.AddDays(-10),
                    EndDate = DateTime.Now.AddDays(10),
                    CinemaId = cinema3.Id,
                    ProducerId = producer3.Id,
                    MovieCategory = MovieCategory.Documentary
                };

                Movie movie2 = new Movie()
                {
                    Id = Guid.NewGuid(),
                    Name = "The Shawshank Redemption",
                    Description = "This is the Shawshank Redemption description",
                    Price = 29.50,
                    ImageURL = "http://dotnethow.net/images/movies/movie-1.jpeg",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(3),
                    CinemaId = cinema1.Id,
                    ProducerId = producer1.Id,
                    MovieCategory = MovieCategory.Action
                };

                Movie movie3 = new Movie()
                {
                    Id = Guid.NewGuid(),
                    Name = "Ghost",
                    Description = "This is the Ghost movie description",
                    Price = 39.50,
                    ImageURL = "http://dotnethow.net/images/movies/movie-4.jpeg",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(7),
                    CinemaId = cinema4.Id,
                    ProducerId = producer4.Id,
                    MovieCategory = MovieCategory.Horror
                };

                Movie movie4 = new Movie()
                {
                    Id = Guid.NewGuid(),
                    Name = "Race",
                    Description = "This is the Race movie description",
                    Price = 39.50,
                    ImageURL = "http://dotnethow.net/images/movies/movie-6.jpeg",
                    StartDate = DateTime.Now.AddDays(-10),
                    EndDate = DateTime.Now.AddDays(-5),
                    CinemaId = cinema1.Id,
                    ProducerId = producer2.Id,
                    MovieCategory = MovieCategory.Documentary
                };

                Movie movie5 = new Movie()
                {
                    Id = Guid.NewGuid(),
                    Name = "Scoob",
                    Description = "This is the Scoob movie description",
                    Price = 39.50,
                    ImageURL = "http://dotnethow.net/images/movies/movie-7.jpeg",
                    StartDate = DateTime.Now.AddDays(-10),
                    EndDate = DateTime.Now.AddDays(-2),
                    CinemaId = cinema1.Id,
                    ProducerId = producer3.Id,
                    MovieCategory = MovieCategory.Cartoon
                };

                Movie movie6 = new Movie()
                {
                    Id = Guid.NewGuid(),
                    Name = "Cold Soles",
                    Description = "This is the Cold Soles movie description",
                    Price = 39.50,
                    ImageURL = "http://dotnethow.net/images/movies/movie-8.jpeg",
                    StartDate = DateTime.Now.AddDays(3),
                    EndDate = DateTime.Now.AddDays(20),
                    CinemaId = cinema1.Id,
                    ProducerId = producer5.Id,
                    MovieCategory = MovieCategory.Drama
                };

                ActorMovie actorMovie1 = new ActorMovie()
                {
                    ActorId = actor1.Id,
                    MovieId = movie1.Id
                };

                ActorMovie actorMovie2 = new ActorMovie()
                {
                    ActorId = actor3.Id,
                    MovieId = movie1.Id
                };

                ActorMovie actorMovie3 = new ActorMovie()
                {
                    ActorId = actor1.Id,
                    MovieId = movie2.Id
                };

                ActorMovie actorMovie4 = new ActorMovie()
                {
                    ActorId = actor4.Id,
                    MovieId = movie2.Id
                };

                ActorMovie actorMovie5 = new ActorMovie()
                {
                    ActorId = actor1.Id,
                    MovieId = movie3.Id
                };

                ActorMovie actorMovie6 = new ActorMovie()
                {
                    ActorId = actor2.Id,
                    MovieId = movie3.Id
                };

                ActorMovie actorMovie7 = new ActorMovie()
                {
                    ActorId = actor5.Id,
                    MovieId = movie3.Id
                };

                ActorMovie actorMovie8 = new ActorMovie()
                {
                    ActorId = actor2.Id,
                    MovieId = movie4.Id
                };

                ActorMovie actorMovie9 = new ActorMovie()
                {
                    ActorId = actor3.Id,
                    MovieId = movie4.Id
                };

                ActorMovie actorMovie10 = new ActorMovie()
                {
                    ActorId = actor4.Id,
                    MovieId = movie4.Id
                };

                ActorMovie actorMovie11 = new ActorMovie()
                {
                    ActorId = actor2.Id,
                    MovieId = movie5.Id
                };

                ActorMovie actorMovie12 = new ActorMovie()
                {
                    ActorId = actor3.Id,
                    MovieId = movie5.Id,
                };

                ActorMovie actorMovie13 = new ActorMovie()
                {
                    ActorId = actor4.Id,
                    MovieId = movie5.Id
                };

                ActorMovie actorMovie14 = new ActorMovie()
                {
                    ActorId = actor5.Id,
                    MovieId = movie5.Id
                };

                ActorMovie actorMovie15 = new ActorMovie()
                {
                    ActorId = actor3.Id,
                    MovieId = movie6.Id
                };

                ActorMovie actorMovie16 = new ActorMovie()
                {
                    ActorId = actor4.Id,
                    MovieId = movie6.Id
                };

                ActorMovie actorMovie17 = new ActorMovie()
                {
                    ActorId = actor5.Id,
                    MovieId = movie6.Id
                };

                //Cinema
                if (!context.Cinemas.Any())
                {
                    context.Cinemas.AddRange(new List<Cinema>()
                    {
                        cinema1,
                        cinema2,
                        cinema3,
                        cinema4,
                        cinema5
                    });

                    context.SaveChanges();
                }

                //Actors
                if (!context.Actors.Any())
                {
                    context.Actors.AddRange(new List<Actor>()
                    {
                        actor1,
                        actor2,
                        actor3,
                        actor4,
                        actor5
                    });

                    context.SaveChanges();
                }

                //Producers
                if (!context.Producers.Any())
                {
                    context.Producers.AddRange(new List<Producer>()
                    {
                        producer1,
                        producer2,
                        producer3,
                        producer4,
                        producer5
                    });

                    context.SaveChanges();
                }

                //Movies
                if (!context.Movies.Any())
                {
                    context.Movies.AddRange(new List<Movie>()
                    {
                        movie1,
                        movie2,
                        movie3,
                        movie4,
                        movie5,
                        movie6
                    });

                    context.SaveChanges();
                }

                //Actors & Movies
                if (!context.ActorMovies.Any())
                {
                    context.ActorMovies.AddRange(new List<ActorMovie>()
                    {
                        actorMovie1,
                        // actorMovie2,
                        actorMovie3,
                        actorMovie4,
                        actorMovie5,
                        actorMovie6,
                        actorMovie7,
                        actorMovie8,
                        actorMovie9,
                        actorMovie10,
                        actorMovie11,
                        actorMovie12,
                        actorMovie13,
                        actorMovie14,
                        actorMovie15,
                        actorMovie16,
                        actorMovie17
                    });

                    context.SaveChanges();
                }
            }
        }
    }
}
