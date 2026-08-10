using Microsoft.AspNetCore.Mvc;
using PortfolioApp.Data.Context;
using PortfolioApp.Data.Entities;

namespace PortfolioApp.Controllers
{
    public class EducationController : Controller
    {
        private readonly AppDBContext _context;

        public EducationController(AppDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var educations = _context.Educations.ToList();
            return View(educations);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Education education)
        {
            _context.Educations.Add(education);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var education = _context.Educations.Find(id);
            if (education == null)
            {
                return NotFound();
            }
            return View(education);
        }

        [HttpPost]
        public IActionResult Update(Education education)
        {
            var egitim = _context.Educations.Find(education.Id);
            if (education == null)
            {
                return NotFound();
            }

            egitim.SchoolName = education.SchoolName;
            egitim.Departman = education.Departman;
            egitim.GPA = education.GPA;
            egitim.StartYear = education.StartYear;
            egitim.GradeationYear = education.GradeationYear;
            egitim.Description = education.Description;

            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var education = _context.Educations.Find(id);
            if (education != null)
            {
                _context.Educations.Remove(education);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
