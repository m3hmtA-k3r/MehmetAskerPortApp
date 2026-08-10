using Microsoft.AspNetCore.Mvc;
using PortfolioApp.Data.Context;
using PortfolioApp.Data.Entities;

namespace PortfolioApp.Controllers
{
    public class TechStackController : Controller
    {
        private readonly AppDBContext _context;

        public TechStackController(AppDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var techStacks = _context.TechStacks.ToList();
            return View(techStacks);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TechStack techStack)
        {
            _context.TechStacks.Add(techStack);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var techStack = _context.TechStacks.Find(id);
            if (techStack == null)
            {
                return NotFound();
            }
            return View(techStack);
        }

        [HttpPost]
        public IActionResult Update(TechStack techStack)
        {
            _context.TechStacks.Update(techStack);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var techStack = _context.TechStacks.Find(id);
            if (techStack != null)
            {
                _context.TechStacks.Remove(techStack);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
