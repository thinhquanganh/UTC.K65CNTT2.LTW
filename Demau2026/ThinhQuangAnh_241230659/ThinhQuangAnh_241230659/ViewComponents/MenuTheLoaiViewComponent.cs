using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ThinhQuangAnh_241230659.Models;

namespace ThinhQuangAnh_241230659.ViewComponents
{
    public class MenuTheLoaiViewComponent : ViewComponent
    {
        private readonly QlnhaSachContext _context;
        public MenuTheLoaiViewComponent(QlnhaSachContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke() {
            var dsTheLoai= _context.TheLoais.ToList();
            return View(dsTheLoai);

        }
        }

}
