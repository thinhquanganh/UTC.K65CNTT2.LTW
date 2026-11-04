
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TqaLesson11Lap04.Data;

namespace TqaLesson11Lap04.ViewComponents
{
    public class MajorViewComponent : ViewComponent
    {
        private readonly SchoolContext db;

        public MajorViewComponent(SchoolContext context)
        {
            db = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var majors = await db.Majors
                .OrderBy(m => m.MajorID)
                .ToListAsync();

            return View("RenderMajor", majors);
        }
    }
}
