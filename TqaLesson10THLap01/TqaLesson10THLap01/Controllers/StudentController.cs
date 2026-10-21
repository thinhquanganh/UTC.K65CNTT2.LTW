
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TqaLesson10THLap01.Models;

namespace TqaLesson10THLap01.Controllers
{
    [Route("Admin/Student")]
    public class StudentController : Controller
    {
        private readonly IWebHostEnvironment _environment;

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

        public StudentController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        [HttpGet("List")]
        public IActionResult Index()
        {
            return View(listStudents);
        }

        [HttpGet("Add")]
        public IActionResult Create()
        {
            LoadFormData();
            return View(new StudentCreateViewModel());
        }

        [HttpPost("Add")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StudentCreateViewModel model)
        {
            if (model.Photo != null && model.Photo.Length > 0)
            {
                var extension = Path.GetExtension(model.Photo.FileName).ToLowerInvariant();
                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };

                if (!allowedExtensions.Contains(extension) ||
                    model.Photo.Length > 2 * 1024 * 1024)
                {
                    ModelState.AddModelError("Photo", "Chỉ chấp nhận JPG, PNG tối đa 2 MB.");
                }
                else
                {
                    var uploadsFolder = Path.Combine(
                        _environment.WebRootPath, "uploads");

                    Directory.CreateDirectory(uploadsFolder);

                    var fileName = Guid.NewGuid().ToString() + extension;
                    var filePath = Path.Combine(uploadsFolder, fileName);

                    using (var stream = new FileStream(filePath, FileMode.CreateNew))
                    {
                        await model.Photo.CopyToAsync(stream);
                    }

                    model.Student.Image = "/uploads/" + fileName;
                }
            }

            if (!ModelState.IsValid)
            {
                LoadFormData();
                return View(model);
            }

            model.Student.Id = listStudents.Max(x => x.Id) + 1;
            listStudents.Add(model.Student);

            return RedirectToAction(nameof(Index));
        }

        private void LoadFormData()
        {
            ViewBag.AllGenders = Enum.GetValues<Gender>().ToList();

            ViewBag.AllBranches = new List<SelectListItem>
            {
                new SelectListItem { Text = "IT", Value = "0" },
                new SelectListItem { Text = "BE", Value = "1" },
                new SelectListItem { Text = "CE", Value = "2" },
                new SelectListItem { Text = "EE", Value = "3" }
            };
        }
    }
}
