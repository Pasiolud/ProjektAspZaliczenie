using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjektAsp.Models;

namespace ProjektAsp.ViewComponents
{
    public class GymStatsViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public GymStatsViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var stats = new GymSummaryViewModel
            {
                MembersCount = await _context.Members.CountAsync(),
                TrainersCount = await _context.Trainers.CountAsync(),
                ClassesCount = await _context.GroupClasses.CountAsync()
            };

            return View(stats);
        }
    }

    public class GymSummaryViewModel
    {
        public int MembersCount { get; set; }
        public int TrainersCount { get; set; }
        public int ClassesCount { get; set; }
    }
}
