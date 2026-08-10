  using Microsoft.AspNetCore.Mvc;
using PortfolioApp.Data.Context;

namespace PortfolioApp.ViewComponents.BoLayout
{
    public class _HeaderProfileViewComponent : ViewComponent
    {
        private readonly AppDBContext _context;

        public _HeaderProfileViewComponent(AppDBContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var about = _context.Abouts.FirstOrDefault();
            return View(about);
        }
    }
}
