using Microsoft.AspNetCore.Mvc;
using ThinhQuangAnh_241230659.Models;

namespace ThinhQuangAnh_241230659.ViewComponents
{
    public class MenuLoaiHangViewComponent : ViewComponent
    {
        private readonly QlhangHoaContext _context;
        public MenuLoaiHangViewComponent(QlhangHoaContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var dsLoai = _context.LoaiHangs.ToList();
            return View(dsLoai);

        }
    }
}
