using Microsoft.AspNetCore.Mvc;
using TqaLesson04.Models;

namespace TqaLesson04.ViewComponents
{
    public class BookViewComponent : ViewComponent
    {
        protected Book book = new Book();

        public IViewComponentResult Invoke()
        {
            var books = book.GetBookList();
            return View(books);
        }
    }
}