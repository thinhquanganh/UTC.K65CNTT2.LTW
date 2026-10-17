
using Microsoft.AspNetCore.Mvc;

namespace TqaLesson09.ViewComponents
{
    public class NavLeftViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
