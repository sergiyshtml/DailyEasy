using DailyEasy.Data;
using DailyEasy.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DailyEasy.Controllers
{
    public class TabsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TabsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Leggings()
        {
            var leggings = await _context.Leggings
                .Include(l => l.Photos)
                .ToListAsync();
            return View(leggings);
        }
    }
}
