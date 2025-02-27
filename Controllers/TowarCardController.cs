using DailyEasy.Data;
using DailyEasy.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DailyEasy.Controllers
{
    public class TowarCardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TowarCardController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> LeggingsTowar(int id)
        {
            var legging = await _context.Leggings
                .Include(l => l.Categori)
                .Include(l => l.Color)
                .Include(l => l.Size)
                .Include(l => l.Photos)
                .FirstOrDefaultAsync(l => l.Id == id);

            if (legging == null)
            {
                return NotFound();
            }

            return View(legging);
        }
    }
}

