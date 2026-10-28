
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TqaLesson11Lap04_DBFirst.Data;
using TqaLesson11Lap04_DBFirst.Models;

namespace TqaLesson11Lap04_DBFirst.Controllers
{
    public class LearnersController : Controller
    {
        private readonly SchoolContext _context;

        public LearnersController(SchoolContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var learners = await _context.Learners
                .Include(l => l.Major)
                .OrderBy(l => l.LearnerId)
                .ToListAsync();

            return View(learners);
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var learner = await _context.Learners
                .Include(l => l.Major)
                .FirstOrDefaultAsync(l => l.LearnerId == id);

            if (learner == null)
            {
                return NotFound();
            }

            return View(learner);
        }


        [HttpGet]
        public IActionResult Create()
        {
            LoadMajors();

            return View(new Learner
            {
                EnrollmentDate = DateTime.Today
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("LastName,FirstMidName,EnrollmentDate,MajorId")]
            Learner learner)
        {
            ModelState.Remove(nameof(Learner.Major));
            ModelState.Remove(nameof(Learner.Enrollments));

            if (ModelState.IsValid)
            {
                _context.Learners.Add(learner);
                await _context.SaveChangesAsync();

                TempData["Success"] = "Thêm người học thành công!";
                return RedirectToAction(nameof(Index));
            }

            LoadMajors(learner.MajorId);
            return View(learner);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var learner = await _context.Learners.FindAsync(id);

            if (learner == null)
                return NotFound();

            LoadMajors(learner.MajorId);
            return View(learner);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            int id,
            [Bind("LearnerId,LastName,FirstMidName,EnrollmentDate,MajorId")]
            Learner learner)
        {
            if (id != learner.LearnerId)
                return NotFound();

            ModelState.Remove(nameof(Learner.Major));
            ModelState.Remove(nameof(Learner.Enrollments));

            if (ModelState.IsValid)
            {
                var existingLearner = await _context.Learners.FindAsync(id);

                if (existingLearner == null)
                    return NotFound();

                existingLearner.LastName = learner.LastName;
                existingLearner.FirstMidName = learner.FirstMidName;
                existingLearner.EnrollmentDate = learner.EnrollmentDate;
                existingLearner.MajorId = learner.MajorId;

                await _context.SaveChangesAsync();

                TempData["Success"] = "Cập nhật người học thành công!";
                return RedirectToAction(nameof(Index));
            }

            LoadMajors(learner.MajorId);
            return View(learner);
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var learner = await _context.Learners
                .Include(l => l.Major)
                .Include(l => l.Enrollments)
                .FirstOrDefaultAsync(l => l.LearnerId == id);

            if (learner == null)
            {
                return NotFound();
            }

            if (learner.Enrollments.Any())
            {
                TempData["Error"] = "Không thể xóa người học đã đăng ký học phần!";
                return RedirectToAction(nameof(Index));
            }

            return View(learner);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int learnerid)
        {
            var learner = await _context.Learners
                .Include(l => l.Enrollments)
                .FirstOrDefaultAsync(l => l.LearnerId == learnerid);

            if (learner == null)
            {
                return NotFound();
            }

            if (learner.Enrollments.Any())
            {
                TempData["Error"] = "Không thể xóa người học đã đăng ký học phần!";
                return RedirectToAction(nameof(Index));
            }

            _context.Learners.Remove(learner);
            await _context.SaveChangesAsync();

            TempData["Success"] = "Xóa người học thành công!";

            return RedirectToAction(nameof(Index));
        }


        private void LoadMajors(int? selectedId = null)
        {
            ViewBag.MajorId = new SelectList(
                _context.Majors.OrderBy(m => m.MajorName),
                "MajorId",
                "MajorName",
                selectedId);
        }
    }
}
