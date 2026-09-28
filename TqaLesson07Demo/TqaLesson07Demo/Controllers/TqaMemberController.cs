using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TqaLesson07Demo.Models;

namespace TqaLesson07Demo.Controllers
{
    public class TqaMemberController : Controller
    {
        private static List<TqaMember> tqaMembers = new List<TqaMember>();
        // GET: TqaMemberController
        public ActionResult Index()
        {
            return View(tqaMembers);
        }

        // GET: TqaMemberController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TqaMemberController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TqaMemberController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TqaMember tqaMember)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(tqaMember);
                }
                
                tqaMembers.Add(tqaMember);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TqaMemberController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TqaMemberController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TqaMemberController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TqaMemberController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
