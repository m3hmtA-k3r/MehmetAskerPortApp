using Microsoft.AspNetCore.Mvc;
using PortfolioApp.Data.Context;
using PortfolioApp.Data.Entities;

namespace PortfolioApp.Controllers
{
    public class TestimonialController : Controller
    {
        private readonly AppDBContext _context;

        public TestimonialController(AppDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var testimonials = _context.Testimonials.ToList();
            return View(testimonials);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Testimonial testimonial)
        {
            _context.Testimonials.Add(testimonial);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var testimonial = _context.Testimonials.Find(id);
            if (testimonial == null)
            {
                return NotFound();
            }
            return View(testimonial);
        }

        [HttpPost]
        public IActionResult Update(Testimonial testimonial)
        {
            _context.Testimonials.Update(testimonial);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var testimonial = _context.Testimonials.Find(id);
            if (testimonial != null)
            {
                _context.Testimonials.Remove(testimonial);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
