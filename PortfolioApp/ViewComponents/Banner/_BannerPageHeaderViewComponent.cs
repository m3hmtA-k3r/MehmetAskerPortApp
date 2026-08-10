using Microsoft.AspNetCore.Mvc;

namespace PortfolioApp.ViewComponents.Banner
{
    public class _BannerPageHeaderViewComponent: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}
