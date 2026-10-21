
using Microsoft.AspNetCore.Mvc;
using TqaLesson10THLap02.Models;

namespace TqaLesson10THLap02.Controllers
{
    public class StudentController : Controller
    {
        private static List<Student> listStudents = new List<Student>
        {
            new Student
            {
                Id = 101,
                Name = "Hải Nam",
                Branch = Branch.IT,
                Gender = Gender.Male,
                IsRegular = true,
                Address = "A1-2018",
                Email = "nam@gmail.com",
                DateOfBirth = new DateTime(2001, 1, 1)
            },
            new Student
            {
                Id = 102,
                Name = "Minh Tú",
                Branch = Branch.BE,
                Gender = Gender.Female,
                IsRegular = true,
                Address = "A1-2019",
                Email = "tu@gmail.com",
                DateOfBirth = new DateTime(2001, 1, 1)
            },
            new Student
            {
                Id = 103,
                Name = "Hoàng Phong",
                Branch = Branch.CE,
                Gender = Gender.Male,
                IsRegular = false,
                Address = "A1-2020",
                Email = "phong@gmail.com",
                DateOfBirth = new DateTime(2001, 1, 1)
            },
            new Student
            {
                Id = 104,
                Name = "Xuân Mai",
                Branch = Branch.EE,
                Gender = Gender.Female,
                IsRegular = false,
                Address = "A1-2021",
                Email = "mai@gmail.com",
                DateOfBirth = new DateTime(2001, 1, 1)
            }
        };

        [HttpGet]
        public IActionResult Index()
        {
            return View(listStudents);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student student)
        {
            student.Id = listStudents.Max(s => s.Id) + 1;
            listStudents.Add(student);

            return RedirectToAction("Index");
        }
    }
}
