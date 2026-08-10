using Microsoft.AspNetCore.Mvc;

namespace PortfolioApp.ViewComponents.Service
{
    public class _ServiceTableListViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
