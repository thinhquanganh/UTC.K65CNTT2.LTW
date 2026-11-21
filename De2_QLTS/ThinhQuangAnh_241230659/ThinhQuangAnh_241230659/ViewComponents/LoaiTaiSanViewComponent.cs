using Microsoft.AspNetCore.Mvc;
using ThinhQuangAnh_241230659.Models;

namespace ThinhQuangAnh_241230659.ViewComponents
{
    public class LoaiTaiSanViewComponent : ViewComponent
    {
        private readonly QltaiSanContext _db;
        public LoaiTaiSanViewComponent(QltaiSanContext db)
        {
            _db = db;
        }
        public IViewComponentResult Invoke()
        {
            var loaiTaiSans = _db.LoaiTaiSans.ToList();
            return View("RenderLoaiTaiSan", loaiTaiSans);
        }
    }
}
