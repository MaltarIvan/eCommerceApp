using eTickets.Data;
using eTickets.Data.Services.Actors;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorsService _service;

        public ActorsController(IActorsService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();

            return View(data);
        }

        // Get Actors/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("ProfilePictureURL, FullName, Bio")]Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }

            await _service.AddAsync(actor);

            return RedirectToAction(nameof(Index));
        }

        // Get Actors/Edit/{id}
        public async Task<IActionResult> Edit(Guid id)
        {
            Actor actor = await _service.GetByIdAsync(id);

            if (actor == null)
            {
                return View("NotFound");
            }

            return View(actor);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id, ProfilePictureURL, FullName, Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }

            await _service.UpdateAsync(id, actor);

            return RedirectToAction(nameof(Index));
        }

        // Get Actors/Delete/{id}
        public async Task<IActionResult> Delete(Guid id)
        {
            Actor actor = await _service.GetByIdAsync(id);

            if (actor == null)
            {
                return View("NotFound");
            }

            return View(actor);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            Actor actor = await _service.GetByIdAsync(id);

            if (actor == null)
            {
                return View("NotFound");
            }

            await _service.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }

        // Get: Actors/Details/{id}
        public async Task<IActionResult> Details(Guid id)
        {
            Actor actor = await _service.GetByIdAsync(id);

            if (actor == null)
            {
                return View("NotFound");
            }

            return View(actor);
        }
    }
}
