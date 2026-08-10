using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioApp.Data.Context;
using PortfolioApp.Data.Entities;

namespace PortfolioApp.Controllers
{
    public class ProjectTechStackController : Controller
    {
        private readonly AppDBContext _context;

        public ProjectTechStackController(AppDBContext context)
        {
            _context = context;
        }

        //Eager Loading
        public IActionResult Index()
        {
            var list = _context.ProjectTechStacks
                .Include(x => x.Project)
                .Include(p => p.TechStack)
                .ToList();
            return View(list);
        }
        

        public IActionResult Create()
        {
            ViewBag.Projects = _context.Projects.ToList();
            ViewBag.TechStacks = _context.TechStacks.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProjectTechStack techStack)
        {
            _context.ProjectTechStacks.Add(techStack);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult Update(int id)
        {
            var techStack = _context.ProjectTechStacks.Find(id);
            if (techStack == null)
            {
                return NotFound();
            }

            ViewBag.Projects = _context.Projects.ToList();
            ViewBag.TechStacks = _context.TechStacks.ToList();
            return View(techStack);
        }

        [HttpPost]
        public IActionResult Update(ProjectTechStack techStack)
        {
            _context.ProjectTechStacks.Update(techStack);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var value = _context.ProjectTechStacks.Find(id);
            if (value == null) return NotFound();
            
            _context.ProjectTechStacks.Remove(value);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
