using Microsoft.AspNetCore.Mvc;

namespace PortfolioApp.ViewComponents.BoLayout
{
    public class _FooterViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
