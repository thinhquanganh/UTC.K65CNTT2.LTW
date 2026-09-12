using Microsoft.AspNetCore.Mvc;
using TqaLesson04.Models;

namespace TqaLesson04.Controllers
{
    public class BookController : Controller
    {
        protected Book book = new Book();
        public IActionResult Index()
        {
            var books = book.GetBookList();
            return View(books);
        }
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            var model = book.GetBookById(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        public PartialViewResult PopularBook()
        {
            var books = book.GetBookList();
            return PartialView("_BookPartial", books);
        }
    }
}