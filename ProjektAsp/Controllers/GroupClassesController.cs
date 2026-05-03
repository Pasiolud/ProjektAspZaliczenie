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
            var classes = await _context.GroupClasses.Include(g => g.Members).ToListAsync();
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

        public async Task<IActionResult> Enroll(int? id)
        {
            if (id == null) return NotFound();

            var groupClass = await _context.GroupClasses
                .Include(g => g.Members)
                .FirstOrDefaultAsync(m => m.Id == id);
            
            if (groupClass == null) return NotFound();

            ViewBag.MembersList = await _context.Members.ToListAsync();
            return View(groupClass);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Enroll(int id, int memberId)
        {
            var groupClass = await _context.GroupClasses
                .Include(g => g.Members)
                .FirstOrDefaultAsync(m => m.Id == id);

            var member = await _context.Members.FindAsync(memberId);

            if (groupClass != null && member != null)
            {
                if (groupClass.Members == null) groupClass.Members = new List<Member>();
                
                if (!groupClass.Members.Contains(member))
                {
                    groupClass.Members.Add(member);
                    await _context.SaveChangesAsync();
                }
                return RedirectToAction(nameof(Index));
            }

            return NotFound();
        }
    }
}
