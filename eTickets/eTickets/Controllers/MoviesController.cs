using eTickets.Data;
using eTickets.Data.Services.Movies;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMoviesService _service;

        public MoviesController(IMoviesService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync(n => n.Cinema);

            return View(data);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            Movie movies = await _service.GetMovieByIdAsync(id);

            if (movies == null)
            {
                return View("NotFound");
            }

            return View(movies);
        }
    }
}
