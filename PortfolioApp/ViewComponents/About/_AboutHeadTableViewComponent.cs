using Microsoft.AspNetCore.Mvc;

namespace PortfolioApp.ViewComponents.About
{
    public class _AboutHeadTableViewComponent : ViewComponent
    {
       public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
