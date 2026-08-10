using Microsoft.AspNetCore.Mvc;
using PortfolioApp.Data.Context;

namespace PortfolioApp.ViewComponents.Default_index
{
    public class _DefaultServicesViewComponent : ViewComponent
    {
        private readonly AppDBContext _context;

        public _DefaultServicesViewComponent(AppDBContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var services = _context.Services.ToList();
            return View(services);
        }
    }
}
