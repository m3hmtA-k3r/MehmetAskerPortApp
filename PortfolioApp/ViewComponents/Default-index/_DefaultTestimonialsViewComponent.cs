using Microsoft.AspNetCore.Mvc;
using PortfolioApp.Data.Context;

namespace PortfolioApp.ViewComponents.Default_index
{
    public class _DefaultTestimonialsViewComponent : ViewComponent
    {
        private readonly AppDBContext _context;

        public _DefaultTestimonialsViewComponent(AppDBContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var testimonials = _context.Testimonials.ToList();
            return View(testimonials);
        }
    }
}
