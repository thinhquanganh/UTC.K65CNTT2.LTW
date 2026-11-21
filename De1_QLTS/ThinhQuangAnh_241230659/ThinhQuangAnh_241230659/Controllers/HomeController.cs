using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ThinhQuangAnh_241230659.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ThinhQuangAnh_241230659.Controllers
{
    public class HomeController : Controller
    {
        private readonly QltaiSanContext _db;
        public HomeController(QltaiSanContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var danhSachTaiSan = _db.TaiSans
                .Where(x => x.NguyenGia != null && x.NguyenGia >=20).ToList();
            ViewBag.TieuDe = "THỊNH QUANG ANH";
            return View(danhSachTaiSan);
        }
        public IActionResult GetTaiSanByLoai(int maLoai, string tenLoai)
        {
            List<TaiSan> danhSachTaiSan;
            if(maLoai == 0)
            {
                danhSachTaiSan = _db.TaiSans
                    .Where(x => x.NguyenGia != null && x.NguyenGia >= 20).ToList();
                ViewBag.TieuDe = "THỊNH QUANG ANH";
            }
            else
            {
                danhSachTaiSan = _db.TaiSans
                    .Where(x => x.MaLoai == maLoai).ToList();
                ViewBag.TieuDe = tenLoai;
            }
            return PartialView("ThinhQuangAnh_MainContent", danhSachTaiSan);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.MaLoai = new SelectList(_db.LoaiTaiSans.ToList(), "MaLoai", "TenLoai");
            return View();
        }
        [HttpPost]
        public IActionResult Create(TaiSan ts)
        {
            if (ModelState.IsValid)
            {
                _db.TaiSans.Add(ts);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaLoai = new SelectList(_db.LoaiTaiSans.ToList(), "MaLoai", "TenLoai", ts.MaLoai);
            return View(ts);
        }

    }
}
