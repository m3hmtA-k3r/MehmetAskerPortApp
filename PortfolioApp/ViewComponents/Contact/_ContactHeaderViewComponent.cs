using Microsoft.AspNetCore.Mvc;

namespace PortfolioApp.ViewComponents.Contact
{
    public class _ContactHeaderViewComponent: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
