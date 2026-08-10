using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PortfolioApp.Data.Context;
using PortfolioApp.Models;

namespace PortfolioApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDBContext _context;
        public HomeController(AppDBContext context)
        {
            _context = context;
        }
       

        public IActionResult Dashboard()
        {
            var viewModal = new DashboardViewModel
            {
                MessageCount = _context.UserMessages.Count(),
                UnreadMessageCount = _context.UserMessages.Count(z => !z.IsRead),
                ExperienceCount = _context.Experiences.Count(),
                ProjectCount = _context.Projects.Count(),
                RecentProjects = _context.Projects.OrderByDescending(i => i.Id ).Take(5).ToList()
            };


            return View(viewModal);
        }

        
    }
}
