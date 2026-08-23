using Microsoft.AspNetCore.Mvc;

namespace TqaLesson02.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
