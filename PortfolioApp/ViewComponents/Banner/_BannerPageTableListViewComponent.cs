using Microsoft.AspNetCore.Mvc;

namespace PortfolioApp.ViewComponents.Banner
{
    public class _BannerPageTableListViewComponent: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();

        }
    }
}
