using Microsoft.AspNetCore.Mvc;

namespace PortfolioApp.ViewComponents.Default_index
{
    public class _DefaultIndexHeadCssViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
