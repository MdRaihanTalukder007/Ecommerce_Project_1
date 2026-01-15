using Ecommerce.Application.Interfaces;
using Ecommerce.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _uow;

        public CategoryController(IUnitOfWork uow) => _uow = uow;

        public async Task<IActionResult> Index()
        {
            ViewBag.ActionName = "Index";  // Pass the action name via ViewBag
            var items = await _uow.Categories.GetAllAsync();
            return View(items.OrderByDescending(x => x.ID).ToList());
        }

        public async Task<IActionResult> Details(int id)
        {
            var item = await _uow.Categories.GetByIdAsync(id);
            if (item is null) return NotFound();
            return View(item);
        }

        public IActionResult Create() => View(new Category());

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category model)
        {
            if (!ModelState.IsValid) return View(model);

            await _uow.Categories.AddAsync(model);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var item = await _uow.Categories.GetByIdAsync(id);
            if (item is null) return NotFound();
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Category model)
        {
            if (id != model.ID) return BadRequest();
            if (!ModelState.IsValid) return View(model);

            _uow.Categories.Update(model);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // public async Task<IActionResult> Delete(int id)
        // {
        //     var item = await _uow.Categories.GetByIdAsync(id);
        //     if (item is null) return NotFound();
        //     return View(item);
        // }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await _uow.Categories.GetByIdAsync(id);
            if (item is null) return NotFound();

            _uow.Categories.Remove(item);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
