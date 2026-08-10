using Microsoft.AspNetCore.Mvc;

namespace PortfolioApp.ViewComponents.Education
{
    public class _EducationHeaderViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
