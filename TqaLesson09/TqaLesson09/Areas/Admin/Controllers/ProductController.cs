
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TqaLesson09.Data;
using TqaLesson09.Models;

namespace TqaLesson09.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _context.Products
                .Include(p => p.Category)
                .OrderByDescending(p => p.Id)
                .ToListAsync();

            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = new SelectList(
                await _context.Categories.OrderBy(c => c.Name).ToListAsync(),
                "Id",
                "Name"
            );

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            ModelState.Remove(nameof(Product.Id));
            ModelState.Remove(nameof(Product.CreatedDate));

            if (await _context.Products.AnyAsync(p => p.Name == product.Name))
            {
                ModelState.AddModelError("Name", "Tên sản phẩm đã tồn tại");
            }

            if (!await _context.Categories.AnyAsync(c => c.Id == product.CategoryId))
            {
                ModelState.AddModelError("CategoryId", "Danh mục không hợp lệ");
            }

            if (ModelState.IsValid)
            {
                product.CreatedDate = DateTime.Today;

                _context.Products.Add(product);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            ViewBag.Categories = new SelectList(
                await _context.Categories.OrderBy(c => c.Name).ToListAsync(),
                "Id",
                "Name",
                product.CategoryId
            );

            return View(product);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            ViewBag.Categories = new SelectList(
                await _context.Categories.OrderBy(c => c.Name).ToListAsync(),
                "Id",
                "Name",
                product.CategoryId
            );

            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            ModelState.Remove(nameof(Product.CreatedDate));

            if (await _context.Products.AnyAsync(p =>
                p.Name == product.Name && p.Id != id))
            {
                ModelState.AddModelError("Name", "Tên sản phẩm đã tồn tại");
            }

            if (!await _context.Categories.AnyAsync(c => c.Id == product.CategoryId))
            {
                ModelState.AddModelError("CategoryId", "Danh mục không hợp lệ");
            }

            if (ModelState.IsValid)
            {
                var existingProduct = await _context.Products.FindAsync(id);

                if (existingProduct == null)
                {
                    return NotFound();
                }

                existingProduct.Name = product.Name;
                existingProduct.Price = product.Price;
                existingProduct.SalePrice = product.SalePrice;
                existingProduct.CategoryId = product.CategoryId;
                existingProduct.Status = product.Status;
                existingProduct.Image = product.Image;
                existingProduct.Description = product.Description;

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            ViewBag.Categories = new SelectList(
                await _context.Categories.OrderBy(c => c.Name).ToListAsync(),
                "Id",
                "Name",
                product.CategoryId
            );

            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

    }
}
