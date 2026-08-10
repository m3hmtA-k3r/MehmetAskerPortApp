using Microsoft.AspNetCore.Mvc;

namespace PortfolioApp.ViewComponents.BoLayout
{
    public class _NavigationViewComponent: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
