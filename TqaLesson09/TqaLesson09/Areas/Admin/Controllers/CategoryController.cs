
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TqaLesson09.Data;
using TqaLesson09.Models;

namespace TqaLesson09.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _context.Categories
                .OrderByDescending(c => c.Id)
                .ToListAsync();

            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            ModelState.Remove(nameof(Category.Id));
            ModelState.Remove(nameof(Category.CreatedDate));

            if (await _context.Categories.AnyAsync(c => c.Name == category.Name))
            {
                ModelState.AddModelError("Name", "Tên danh mục đã tồn tại");
            }

            if (ModelState.IsValid)
            {
                category.CreatedDate = DateTime.Now;

                _context.Categories.Add(category);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(category);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var category = await _context.Categories.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Category category)
        {
            if (id != category.Id)
            {
                return NotFound();
            }

            ModelState.Remove(nameof(Category.CreatedDate));

            if (await _context.Categories.AnyAsync(c =>
                c.Name == category.Name && c.Id != id))
            {
                ModelState.AddModelError("Name", "Tên danh mục đã tồn tại");
            }

            if (ModelState.IsValid)
            {
                var existingCategory = await _context.Categories.FindAsync(id);

                if (existingCategory == null)
                {
                    return NotFound();
                }

                existingCategory.Name = category.Name;
                existingCategory.Status = category.Status;
                existingCategory.Image = category.Image;
                existingCategory.Description = category.Description;

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _context.Categories.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            bool hasProducts = await _context.Products
                .AnyAsync(p => p.CategoryId == id);

            if (hasProducts)
            {
                TempData["Error"] = "Không thể xóa danh mục đang có sản phẩm";
                return RedirectToAction(nameof(Index));
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
