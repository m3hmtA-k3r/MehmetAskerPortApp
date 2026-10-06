using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortfolioApp.Data.Context;
using PortfolioApp.Data.Entities;

namespace PortfolioApp.Controllers
{
    [AllowAnonymous] // AllowAnonymous => bu controller için devre dışı bırakır ve görünmesini saglar
    public class DefaultController : Controller
    {
        private readonly AppDBContext _context;

        public DefaultController(AppDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
         
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SendMesaj(UserMessage userMessage)
        {
            if (string.IsNullOrWhiteSpace(userMessage.Name) ||
                string.IsNullOrWhiteSpace(userMessage.Email) ||
                string.IsNullOrWhiteSpace(userMessage.MessageBody))
            {
                TempData["MessageResult"] = "error";
                return RedirectToAction("Index");
            }

            userMessage.IsRead = false; // overposting koruması: dışarıdan IsRead=true dayatılamasın
            _context.UserMessages.Add(userMessage);
            _context.SaveChanges();

            TempData["MessageResult"] = "success";
            return NoContent();
        }

    }
}
