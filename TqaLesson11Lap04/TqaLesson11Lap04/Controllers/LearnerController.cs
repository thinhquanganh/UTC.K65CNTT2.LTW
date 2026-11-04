
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TqaLesson11Lap04.Data;
using TqaLesson11Lap04.Models;

namespace TqaLesson11Lap04.Controllers
{
    public class LearnerController : Controller
    {
        private readonly SchoolContext db;
        private const int pageSize = 3;

        public LearnerController(SchoolContext context)
        {
            db = context;
        }

        public async Task<IActionResult> Index(
            int? mid, string? keyword, int pageIndex = 1)
        {
            var query = db.Learners
                .Include(l => l.Major)
                .AsQueryable();

            if (mid.HasValue)
            {
                query = query.Where(l => l.MajorID == mid.Value);
            }

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                keyword = keyword.Trim();

                query = query.Where(l =>
                    l.FirstMidName.Contains(keyword));
            }

            int totalItems = await query.CountAsync();

            int pageNum = Math.Max(1,
                (int)Math.Ceiling(totalItems / (double)pageSize));

            pageIndex = Math.Clamp(pageIndex, 1, pageNum);

            ViewBag.PageNum = pageNum;
            ViewBag.PageIndex = pageIndex;
            ViewBag.Mid = mid;
            ViewBag.Keyword = keyword;

            var learners = await query
                .OrderBy(l => l.LearnerID)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return View(learners);
        }

        [HttpGet]
        public async Task<IActionResult> LearnerByMajorID(int? mid)
        {
            return await LearnerFilter(mid, null, 1);
        }

        [HttpGet]
        public async Task<IActionResult> LearnerFilter(
            int? mid, string? keyword, int pageIndex = 1)
        {
            var query = db.Learners
                .Include(l => l.Major)
                .AsQueryable();

            if (mid.HasValue)
            {
                query = query.Where(l => l.MajorID == mid.Value);
            }

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                keyword = keyword.Trim();

                query = query.Where(l =>
                    l.FirstMidName.Contains(keyword));
            }

            int totalItems = await query.CountAsync();

            int pageNum = Math.Max(1,
                (int)Math.Ceiling(totalItems / (double)pageSize));

            pageIndex = Math.Clamp(pageIndex, 1, pageNum);

            ViewBag.PageNum = pageNum;
            ViewBag.PageIndex = pageIndex;
            ViewBag.Mid = mid;
            ViewBag.Keyword = keyword;

            var learners = await query
                .OrderBy(l => l.LearnerID)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return PartialView("LearnerTable", learners);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.MajorID = new SelectList(
                db.Majors, "MajorID", "MajorName");

            return View(new Learner
            {
                EnrollmentDate = DateTime.Today
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("FirstMidName,LastName,MajorID,EnrollmentDate")]
            Learner learner)
        {
            if (ModelState.IsValid)
            {
                db.Learners.Add(learner);
                await db.SaveChangesAsync();

                TempData["Success"] = "Thêm người học thành công!";
                return RedirectToAction(nameof(Index));
            }

            ViewBag.MajorID = new SelectList(
                db.Majors, "MajorID", "MajorName", learner.MajorID);

            return View(learner);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var learner = await db.Learners.FindAsync(id);

            if (learner == null)
            {
                return NotFound();
            }

            ViewBag.MajorID = new SelectList(
                db.Majors, "MajorID", "MajorName", learner.MajorID);

            return View(learner);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            int id,
            [Bind("LearnerID,FirstMidName,LastName,MajorID,EnrollmentDate")]
            Learner learner)
        {
            if (id != learner.LearnerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var existingLearner = await db.Learners.FindAsync(id);

                if (existingLearner == null)
                {
                    return NotFound();
                }

                existingLearner.FirstMidName = learner.FirstMidName;
                existingLearner.LastName = learner.LastName;
                existingLearner.MajorID = learner.MajorID;
                existingLearner.EnrollmentDate = learner.EnrollmentDate;

                await db.SaveChangesAsync();

                TempData["Success"] = "Cập nhật người học thành công!";
                return RedirectToAction(nameof(Index));
            }

            ViewBag.MajorID = new SelectList(
                db.Majors, "MajorID", "MajorName", learner.MajorID);

            return View(learner);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var learner = await db.Learners
                .Include(l => l.Major)
                .Include(l => l.Enrollments)
                .FirstOrDefaultAsync(l => l.LearnerID == id);

            if (learner == null)
            {
                return NotFound();
            }

            if (learner.Enrollments.Any())
            {
                TempData["Error"] =
                    "Người học đã đăng ký học phần nên không thể xóa!";

                return RedirectToAction(nameof(Index));
            }

            return View(learner);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var learner = await db.Learners
                .Include(l => l.Enrollments)
                .FirstOrDefaultAsync(l => l.LearnerID == id);

            if (learner == null)
            {
                return NotFound();
            }

            if (learner.Enrollments.Any())
            {
                TempData["Error"] =
                    "Người học đã đăng ký học phần nên không thể xóa!";

                return RedirectToAction(nameof(Index));
            }

            db.Learners.Remove(learner);
            await db.SaveChangesAsync();

            TempData["Success"] = "Xóa người học thành công!";

            return RedirectToAction(nameof(Index));
        }
    }
}
