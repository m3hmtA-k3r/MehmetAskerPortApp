using Microsoft.AspNetCore.Mvc;
using PortfolioApp.Data.Context;

namespace PortfolioApp.ViewComponents.Default_index
{
    public class _DefaultContactViewComponent : ViewComponent
    {
        private readonly AppDBContext _context;

        public _DefaultContactViewComponent(AppDBContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var contactInfo = _context.ContactInfos.FirstOrDefault();
            return View(contactInfo);
        }
    }
}
