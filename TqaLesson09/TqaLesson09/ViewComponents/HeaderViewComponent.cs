
using Microsoft.AspNetCore.Mvc;

namespace TqaLesson09.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
