using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ThinhQuangAnh_241230659.Models;

namespace ThinhQuangAnh_241230659.Controllers
{
    public class HomeController : Controller
    {
        private readonly QlnhaSachContext _context;
        public HomeController(QlnhaSachContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var dsSach = _context.Saches
            .Where(s => s.Gia !=null&&s.Gia>=100).ToList();
            return View(dsSach);
        }
        public IActionResult LocSachTheoTheLoai(int maTl)
        {
            var dsSach = _context.Saches.Where(s => s.MaTl == maTl).ToList();
            return PartialView("_DanhSachSach", dsSach);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.MaTl = new SelectList(_context.TheLoais, "MaTl", "TenTl");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Sach sach)
        {
            if (ModelState.IsValid)
            {
                _context.Saches.Add(sach);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaTl = new SelectList(_context.TheLoais, "MaTl", "TenTl", sach.MaTl);
            return View(sach);
        }
    }
}
