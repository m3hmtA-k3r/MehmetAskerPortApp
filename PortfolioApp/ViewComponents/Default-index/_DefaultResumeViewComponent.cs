using Microsoft.AspNetCore.Mvc;
using PortfolioApp.Data.Context;
using PortfolioApp.Models;

namespace PortfolioApp.ViewComponents.Default_index
{
    public class _DefaultResumeViewComponent : ViewComponent
    {
        private readonly AppDBContext _context;

        public _DefaultResumeViewComponent(AppDBContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var model = new DefaultResumeViewModel
            {
                Experiences = _context.Experiences
                    .OrderByDescending(e => e.StartYear)
                    .ToList(),
                Educations = _context.Educations
                    .OrderByDescending(e => e.StartYear)
                    .ToList()
            };
            return View(model);
        }
    }
}
