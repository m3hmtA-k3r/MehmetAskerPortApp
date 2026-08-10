using Microsoft.AspNetCore.Mvc;

namespace PortfolioApp.ViewComponents.BoLayout
{
    public class _BoLayOutHeadViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
