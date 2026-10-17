
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TqaLesson09.Data;
using TqaLesson09.Models;

namespace TqaLesson09.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BlogController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var blogs = await _context.Blogs
                .OrderByDescending(b => b.Id)
                .ToListAsync();

            return View(blogs);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Blog blog)
        {
            if (await _context.Blogs.AnyAsync(b => b.Name == blog.Name))
            {
                ModelState.AddModelError("Name", "Tên bài viết đã tồn tại");
            }

            if (ModelState.IsValid)
            {
                blog.CreatedDate = DateTime.Today;

                _context.Blogs.Add(blog);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(blog);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var blog = await _context.Blogs.FindAsync(id);

            if (blog == null)
            {
                return NotFound();
            }

            return View(blog);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Blog blog)
        {
            if (id != blog.Id)
            {
                return NotFound();
            }

            if (await _context.Blogs.AnyAsync(b =>
                b.Name == blog.Name && b.Id != id))
            {
                ModelState.AddModelError("Name", "Tên bài viết đã tồn tại");
            }

            if (ModelState.IsValid)
            {
                var existingBlog = await _context.Blogs.FindAsync(id);

                if (existingBlog == null)
                {
                    return NotFound();
                }

                existingBlog.Name = blog.Name;
                existingBlog.Status = blog.Status;
                existingBlog.Image = blog.Image;
                existingBlog.Description = blog.Description;

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(blog);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var blog = await _context.Blogs.FindAsync(id);

            if (blog == null)
            {
                return NotFound();
            }

            _context.Blogs.Remove(blog);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
