
using Microsoft.AspNetCore.Mvc;
using TqaLesson10THLap02.Models;

namespace TqaLesson10THLap02.ViewComponents
{
    public class RenderViewComponent : ViewComponent
    {
        private readonly List<MenuItem> MenuItems = new List<MenuItem>();

        public RenderViewComponent()
        {
            MenuItems = new List<MenuItem>
            {
                new MenuItem
                {
                    Id = 1,
                    Name = "Branches",
                    Link = "/Branches/List"
                },
                new MenuItem
                {
                    Id = 2,
                    Name = "Students",
                    Link = "/Student/Index"
                },
                new MenuItem
                {
                    Id = 3,
                    Name = "Subjects",
                    Link = "/Subjects/List"
                },
                new MenuItem
                {
                    Id = 4,
                    Name = "Courses",
                    Link = "/Courses/List"
                }
            };
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            await Task.CompletedTask;
            return View("RenderLeftMenu", MenuItems);
        }
    }
}
