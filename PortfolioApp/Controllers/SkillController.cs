using Microsoft.AspNetCore.Mvc;
using PortfolioApp.Data.Context;
using PortfolioApp.Data.Entities;

namespace PortfolioApp.Controllers
{
    public class SkillController : Controller
    {
        private readonly AppDBContext _context;

        public SkillController(AppDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var skills = _context.Skills.ToList();
            return View(skills);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Skill skill)
        {
            _context.Skills.Add(skill);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var skill = _context.Skills.Find(id);
            if (skill == null)
            {
                return NotFound();
            }
            return View(skill);
        }

        [HttpPost]
        public IActionResult Update(Skill skill)
        {
            _context.Skills.Update(skill);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var skill = _context.Skills.Find(id);
            if (skill != null)
            {
                _context.Skills.Remove(skill);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
