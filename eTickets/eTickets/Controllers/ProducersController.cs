using eTickets.Data;
using eTickets.Data.Services.Producers;
using eTickets.Data.Static;
using eTickets.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

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
        [Authorize(Roles = UserRoles.Admin)]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = UserRoles.Admin)]
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
        [Authorize(Roles = UserRoles.Admin)]
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
        [Authorize(Roles = UserRoles.Admin)]
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
        [Authorize(Roles = UserRoles.Admin)]
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
        [Authorize(Roles = UserRoles.Admin)]
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
