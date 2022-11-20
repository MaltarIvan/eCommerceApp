using eTickets.Data;
using eTickets.Data.Services.Producers;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class ProducersController : Controller
    {
        private readonly IProducersService _service;

        public ProducersController(IProducersService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();

            return View(data);
        }

        // Get Producers/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("ProfilePictureURL, FullName, Bio")] Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
            }

            await _service.AddAsync(producer);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(Guid id)
        {
            Producer producer = await _service.GetByIdAsync(id);

            if (producer == null)
            {
                return View("NotFound");
            }

            return View(producer);
        }

        // Get Producers/Edit/{id}
        public async Task<IActionResult> Edit(Guid id)
        {
            Producer producer = await _service.GetByIdAsync(id);

            if (producer == null)
            {
                return View("NotFound");
            }

            return View(producer);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id, ProfilePictureURL, FullName, Bio")] Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
            }

            await _service.UpdateAsync(id, producer);

            return RedirectToAction(nameof(Index));
        }

        // Get Producrs/Delete/{id}
        public async Task<IActionResult> Delete(Guid id)
        {
            Producer producer = await _service.GetByIdAsync(id);

            if (producer == null)
            {
                return View("NotFound");
            }

            return View(producer);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            Producer producer = await _service.GetByIdAsync(id);

            if (producer == null)
            {
                return View("NotFound");
            }

            await _service.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
