
using Microsoft.AspNetCore.Mvc;

namespace TqaLesson09.ViewComponents
{
    public class FooterViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
