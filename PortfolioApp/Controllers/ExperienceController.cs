using Microsoft.AspNetCore.Mvc;
using PortfolioApp.Data.Context;
using PortfolioApp.Data.Entities;

namespace PortfolioApp.Controllers
{
    public class ExperienceController : Controller
    {
        private readonly AppDBContext _context;

        public ExperienceController(AppDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var experiences = _context.Experiences.ToList();
            return View(experiences);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Experience experience)
        {
            _context.Experiences.Add(experience);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var experience = _context.Experiences.Find(id);
            if (experience == null)
            {
                return NotFound();
            }
            return View(experience);
        }

        [HttpPost]
        public IActionResult Update(Experience experience)
        {
            _context.Experiences.Update(experience);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var experience = _context.Experiences.Find(id);
            if (experience != null)
            {
                _context.Experiences.Remove(experience);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
