using Microsoft.AspNetCore.Mvc;
using PortfolioApp.Data.Context;
using PortfolioApp.Data.Entities;
using System.Threading.Tasks;

namespace PortfolioApp.Controllers
{
    public class BannerController : Controller
    {
        private readonly AppDBContext _context;

        public BannerController(AppDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var banners = _context.Banners.ToList();
            return View(banners);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Banner banner, IFormFile image)
        {
            if (image != null && image.Length > 0)
            {
                var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images");
                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);

                var fileName = Guid.NewGuid() + Path.GetExtension(image.FileName);
                var path = Path.Combine(folderPath, fileName);

                using var stream = new FileStream(path, FileMode.Create);
                await image.CopyToAsync(stream);
                banner.ImageUrl = "/Images/" + fileName;
            }

            _context.Banners.Add(banner);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var banner = _context.Banners.Find(id);
            if(banner == null)
            {
                return NotFound();
            }

            return View(banner);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Banner banner, IFormFile? image )
        {
            var afis = _context.Banners.Find(banner.Id);
            if(afis == null)
            {
                return NotFound();
            }

            afis.Title = banner.Title;
            afis.Description = banner.Description;

            if(image !=null && image.Length> 0)
            {
                var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images");
                if(!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);

                var fileName = Guid.NewGuid() + Path.GetExtension(image.FileName);
                var path = Path.Combine(folderPath, fileName);

                using var stream = new FileStream(path, FileMode.Create);
                await image.CopyToAsync(stream);
                afis.ImageUrl = "/Images/" + fileName;
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var afis = _context.Banners.Find(id);
            if(afis != null)
            {
                _context.Banners.Remove(afis);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
