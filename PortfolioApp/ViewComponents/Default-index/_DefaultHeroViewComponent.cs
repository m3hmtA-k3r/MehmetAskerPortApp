using Microsoft.AspNetCore.Mvc;
using PortfolioApp.Data.Context;

namespace PortfolioApp.ViewComponents.Default_index
{
    public class _DefaultHeroViewComponent : ViewComponent
    {
        private readonly AppDBContext _context;

        public _DefaultHeroViewComponent(AppDBContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var banner = _context.Banners.FirstOrDefault();
            return View(banner);
        }
    }
}
