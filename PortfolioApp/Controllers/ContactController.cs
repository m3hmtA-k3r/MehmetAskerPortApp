using Microsoft.AspNetCore.Mvc;
using PortfolioApp.Data.Context;
using PortfolioApp.Data.Entities;

namespace PortfolioApp.Controllers
{
    public class ContactController : Controller
    {
        private readonly AppDBContext _context;

        public ContactController(AppDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var contacts = _context.ContactInfos.ToList();
            return View(contacts);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ContactInfo contactInfo)
        {
            _context.ContactInfos.Add(contactInfo);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var contactInfo = _context.ContactInfos.Find(id);
            if (contactInfo == null)
            {
                return NotFound();
            }
            return View(contactInfo);
        }

        [HttpPost]
        public IActionResult Update(int id, string Email, string Address, string LinkedinUrl, string GithubUrl)
        {
            var contactInfo = _context.ContactInfos.Find(id);
            if (contactInfo == null)
            {
                return NotFound();
            }

            contactInfo.Email = Email;
            contactInfo.Address = Address;
            contactInfo.LinkedinUrl = LinkedinUrl;
            contactInfo.GithubUrl = GithubUrl;

            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var contactInfo = _context.ContactInfos.Find(id);
            if (contactInfo != null)
            {
                _context.ContactInfos.Remove(contactInfo);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
