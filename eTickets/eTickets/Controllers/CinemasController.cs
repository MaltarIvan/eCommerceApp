using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Data.Services.Cinemas;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class CinemasController : Controller
    {
        private readonly ICinemasService _service;

        public CinemasController(ICinemasService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            Cinema cinema = await _service.GetByIdAsync(id);

            if (cinema == null)
            {
                return View("NotFound");
            }

            return View(cinema);
        }

        // Get Cinemas/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("LogoPictureURL, Name, Description")] Cinema cinema)
        {
            if (!ModelState.IsValid)
            {
                return View(cinema);
            }

            await _service.AddAsync(cinema);

            return RedirectToAction(nameof(Index));
        }

        // Get Cinemas/Edit/{id}
        public async Task<IActionResult> Edit(Guid id)
        {
            Cinema cinema = await _service.GetByIdAsync(id);

            if (cinema == null)
            {
                return View("NotFound");
            }

            return View(cinema);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id, LogoPictureURL, Name, Description")] Cinema cinema)
        {
            if (!ModelState.IsValid)
            {
                return View(cinema);
            }

            await _service.UpdateAsync(id, cinema);

            return RedirectToAction(nameof(Index));
        }

        // Get Cinemas/Delete/{id}
        public async Task<IActionResult> Delete(Guid id)
        {
            Cinema cinema = await _service.GetByIdAsync(id);

            if (cinema == null)
            {
                return View("NotFound");
            }

            return View(cinema);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            Cinema cinema = await _service.GetByIdAsync(id);

            if (cinema == null)
            {
                return View("NotFound");
            }

            await _service.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
