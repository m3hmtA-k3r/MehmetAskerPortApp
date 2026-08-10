using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioApp.Data.Context;

namespace PortfolioApp.ViewComponents.Default_index
{
    public class _DefaultProjectsViewComponent : ViewComponent
    {
        private readonly AppDBContext _context;

        public _DefaultProjectsViewComponent(AppDBContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var projects = _context.Projects.Include(p => p.ProjectTexhStacks).ThenInclude(pts => pts.TechStack).ToList();
            return View(projects);
        }
    }
}
