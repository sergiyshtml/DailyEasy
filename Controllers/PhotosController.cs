using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DailyEasy.Models;
using System.IO;
using System.Threading.Tasks;
using DailyEasy.Data;

namespace DailyEasy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PhotosController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("upload/{leggingId}")]
        public async Task<IActionResult> Upload(int leggingId, [FromForm] List<IFormFile> files)
        {
            if (files == null || files.Count == 0)
            {
                return BadRequest("Жоден файл не було завантажено.");
            }

            var legging = await _context.Leggings.FindAsync(leggingId);
            if (legging == null)
            {
                return NotFound($"Легінси з ID {leggingId} не знайдено.");
            }

            // Створюємо папку, якщо її не існує
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
                    LeggingId = leggingId
                };

                _context.Photos.Add(photo);
            }

            await _context.SaveChangesAsync();
            return Ok(new { message = "Фото успішно завантажено." });
        }
    }
}
