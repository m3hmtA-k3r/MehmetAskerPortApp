using Microsoft.AspNetCore.Mvc;
using PortfolioApp.Data.Context;

namespace PortfolioApp.Controllers
{
    public class UserMessageController : Controller
    {
        private readonly AppDBContext _context;

        public UserMessageController(AppDBContext context)
        {
            _context = context;
        }

        public IActionResult Index(string filter = "all")
        {
            var query = _context.UserMessages.AsQueryable();

            if (filter == "unread")
                query = query.Where(m => !m.IsRead);
            else if (filter == "read")
                query = query.Where(m => m.IsRead);

            var messages = query
                .OrderBy(m => m.IsRead)
                .ThenByDescending(m => m.Id)
                .ToList();

            ViewBag.CurrentFilter = filter;
            ViewBag.UnreadCount = _context.UserMessages.Count(m => !m.IsRead);
            return View(messages);
        }


        public IActionResult Details(int id)
        {
            var message = _context.UserMessages.Find(id);
            if (message == null)
                return NotFound();

            if (!message.IsRead)
            {
                message.IsRead = true;
                _context.SaveChanges();
            }

            return PartialView(message);
        }


        [HttpPost]
        public IActionResult Delete(int id)
        {
            var message = _context.UserMessages.Find(id);
            if (message == null)
                return NotFound();

            _context.UserMessages.Remove(message);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
