using Microsoft.AspNetCore.Mvc;
using PortfolioApp.Data.Context;
using PortfolioApp.Models;

namespace PortfolioApp.ViewComponents.Default_index
{
    public class _DefaultAboutViewComponent : ViewComponent
    {
        private readonly AppDBContext _context;

        public _DefaultAboutViewComponent(AppDBContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var model = new DefaultAboutViewModel
            {
                About = _context.Abouts.FirstOrDefault(),
                Skills = _context.Skills.Where(s => s.IsActive).ToList()
            };
            return View(model);
        }
    }
}
