
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TqaLesson11Lap03.Models;

namespace TqaLesson11Lap03.Controllers
{
    public class StudentController : Controller
    {
        private static readonly List<Student> listStudents = new List<Student>();

        private void LoadData()
        {
            ViewBag.AllGenders = Enum.GetValues<Gender>().ToList();

            ViewBag.AllBranches = new List<SelectListItem>
            {
                new SelectListItem { Text = "IT", Value = "1" },
                new SelectListItem { Text = "BE", Value = "2" },
                new SelectListItem { Text = "CE", Value = "3" },
                new SelectListItem { Text = "EE", Value = "4" }
            };
        }

        public IActionResult Index()
        {
            return View(listStudents);
        }

        [HttpGet]
        public IActionResult Create()
        {
            LoadData();
            return View(new Student());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student s)
        {
            if (ModelState.IsValid)
            {
                s.Id = listStudents.Count == 0
                    ? 1
                    : listStudents.Max(x => x.Id) + 1;

                listStudents.Add(s);

                TempData["Success"] = "Thêm sinh viên thành công!";

                return RedirectToAction(nameof(Index));
            }

            LoadData();
            return View(s);
        }
    }
}
