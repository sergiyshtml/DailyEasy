using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DailyEasy.Models;
using DailyEasy.Data;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace DailyEasy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeggingsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LeggingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload([FromForm] Legging legging, [FromForm] List<IFormFile> files)
        {
            _context.Leggings.Add(legging);
            await _context.SaveChangesAsync();

            var imagesPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
            if (!Directory.Exists(imagesPath))
            {
                Directory.CreateDirectory(imagesPath);
            }

            foreach (var file in files)
            {
                var fileName = Path.GetFileName(file.FileName);
                var filePath = Path.Combine(imagesPath, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                var photo = new Photo
                {
                    Url = $"/images/{fileName}",
                    LeggingId = legging.Id
                };

                _context.Photos.Add(photo);
            }

            await _context.SaveChangesAsync();
            return Ok(new { message = "Legging and photos uploaded successfully." });
        }
    }
}

