using Microsoft.AspNetCore.Mvc;

namespace PortfolioApp.ViewComponents.Banner
{
    public class _BannerDeleteModelViewComponent: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
