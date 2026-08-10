using Microsoft.AspNetCore.Mvc;

namespace PortfolioApp.ViewComponents.BoLayout
{
    public class _TopAppBarHeaderMobilViewComponent: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
