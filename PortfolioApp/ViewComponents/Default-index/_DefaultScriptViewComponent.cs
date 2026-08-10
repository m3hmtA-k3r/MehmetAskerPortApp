using Microsoft.AspNetCore.Mvc;

namespace PortfolioApp.ViewComponents.Default_index
{
    public class _DefaultScriptViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
