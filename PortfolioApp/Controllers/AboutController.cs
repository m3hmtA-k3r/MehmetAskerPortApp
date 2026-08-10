using Microsoft.AspNetCore.Mvc;
using PortfolioApp.Data.Context;
using PortfolioApp.Data.Entities;
using System.Threading.Tasks;

namespace PortfolioApp.Controllers
{
    public class AboutController : Controller
    {
        private readonly AppDBContext _context;
        public AboutController(AppDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var abouts = _context.Abouts.ToList();
            return View(abouts);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(About about, IFormFile ImageFile)
        {
            if (ImageFile != null && ImageFile.Length > 0)
            {
                var fileName = Guid.NewGuid() + Path.GetExtension(ImageFile.FileName);
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images", fileName);

                using var stream = new FileStream(path, FileMode.Create);
                await ImageFile.CopyToAsync(stream);
                about.ImageUrl = "/Images/" + fileName;
            }

            _context.Abouts.Add(about);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var about = _context.Abouts.Find(id);
            if(about == null)
            {
                return NotFound();
            }
            return View(about);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, About about, IFormFile image)
        {
            var mevcutAbout = await _context.Abouts.FindAsync(id);
            if (mevcutAbout == null)
                return NotFound();

            mevcutAbout.Title = about.Title;
            mevcutAbout.Description = about.Description;

            if (image != null && image.Length > 0)
            {
                var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images");
                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);

                var fileName = Guid.NewGuid() + Path.GetExtension(image.FileName);
                var path = Path.Combine(folderPath, fileName);

                using var stream = new FileStream(path, FileMode.Create);
                await image.CopyToAsync(stream);
                mevcutAbout.ImageUrl = "/Images/" + fileName;
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var about = _context.Abouts.Find(id);
            if(about == null)
                return NotFound();

            _context.Abouts.Remove(about);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
