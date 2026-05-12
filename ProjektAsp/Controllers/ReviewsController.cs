using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjektAsp.Models;

namespace ProjektAsp.Controllers
{
    public class ReviewsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReviewsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var reviews = await _context.Reviews
                .Include(r => r.Member)
                .Include(r => r.Trainer)
                .OrderByDescending(r => r.CreatedDate)
                .ToListAsync();
            return View(reviews);
        }

        public IActionResult Create()
        {
            ViewBag.MemberId = new SelectList(_context.Members, "Id", "LastName");
            ViewBag.TrainerId = new SelectList(_context.Trainers, "Id", "LastName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MemberId,TrainerId,Rating,Comment,CreatedDate")] Review review)
        {
            if (ModelState.IsValid)
            {
                _context.Add(review);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.MemberId = new SelectList(_context.Members, "Id", "LastName", review.MemberId);
            ViewBag.TrainerId = new SelectList(_context.Trainers, "Id", "LastName", review.TrainerId);
            return View(review);
        }
    }
}
