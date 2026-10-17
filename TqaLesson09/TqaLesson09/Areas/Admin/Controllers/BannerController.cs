
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TqaLesson09.Data;
using TqaLesson09.Models;

namespace TqaLesson09.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BannerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BannerController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var banners = await _context.Banners
                .OrderBy(b => b.Prioty)
                .ThenByDescending(b => b.Id)
                .ToListAsync();

            return View(banners);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Banner banner)
        {
            if (await _context.Banners.AnyAsync(b => b.Name == banner.Name))
            {
                ModelState.AddModelError(nameof(Banner.Name), "Tên Banner đã tồn tại");
            }

            if (ModelState.IsValid)
            {
                _context.Banners.Add(banner);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(banner);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var banner = await _context.Banners.FindAsync(id);

            if (banner == null)
            {
                return NotFound();
            }

            return View(banner);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Banner banner)
        {
            if (id != banner.Id)
            {
                return NotFound();
            }

            if (await _context.Banners.AnyAsync(b =>
                b.Name == banner.Name && b.Id != id))
            {
                ModelState.AddModelError(nameof(Banner.Name), "Tên Banner đã tồn tại");
            }

            if (ModelState.IsValid)
            {
                var existingBanner = await _context.Banners.FindAsync(id);

                if (existingBanner == null)
                {
                    return NotFound();
                }

                existingBanner.Name = banner.Name;
                existingBanner.Status = banner.Status;
                existingBanner.Prioty = banner.Prioty;
                existingBanner.Image = banner.Image;
                existingBanner.Description = banner.Description;

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(banner);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var banner = await _context.Banners.FindAsync(id);

            if (banner == null)
            {
                return NotFound();
            }

            _context.Banners.Remove(banner);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
