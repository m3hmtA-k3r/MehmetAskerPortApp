using Microsoft.AspNetCore.Mvc;

namespace PortfolioApp.ViewComponents.Contact
{
    public class _ContactTableListViewComponent:  ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
