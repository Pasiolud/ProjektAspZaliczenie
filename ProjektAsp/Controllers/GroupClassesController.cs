using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjektAsp.Models;

namespace ProjektAsp.Controllers
{
    public class GroupClassesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GroupClassesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var classes = await _context.GroupClasses.ToListAsync();
            return View(classes);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Capacity")] GroupClass groupClass)
        {
            if (ModelState.IsValid)
            {
                _context.Add(groupClass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(groupClass);
        }
    }
}
