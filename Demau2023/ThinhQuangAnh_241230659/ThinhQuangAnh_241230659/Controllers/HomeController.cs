using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ThinhQuangAnh_241230659.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace ThinhQuangAnh_241230659.Controllers
{
    public class HomeController : Controller
    {
        private readonly QlhangHoaContext _context;
        public HomeController(QlhangHoaContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var dsHang = _context.HangHoas.Where(h => h.Gia >=100).ToList();
            return View(dsHang);
        }
        public IActionResult LocHangTheoTheLoai(int maLoai)
        {
            var dsHang = _context.HangHoas.Where(h => h.MaLoai == maLoai).ToList();
            return PartialView("_DanhSachHangHoa", dsHang);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.MaLoai = new SelectList(_context.LoaiHangs, "MaLoai", "TenLoai");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(HangHoa hangHoa)
        {
            if (ModelState.IsValid)
            {
                _context.HangHoas.Add(hangHoa);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaLoai = new SelectList(_context.LoaiHangs, "MaLoai", "TenLoai", hangHoa.MaLoai);
            return View(hangHoa);
        }
    }
}
