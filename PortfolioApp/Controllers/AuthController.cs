using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortfolioApp.Data.Context;
using PortfolioApp.Models;
using System.Security.Claims;

namespace PortfolioApp.Controllers
{
    [AllowAnonymous] // Login sayfasının kendisi kilitli olursa kimse içeri giremez (sonsuz yönlendirme döngüsü)
    public class AuthController : Controller
    {
        private readonly AppDBContext _context;

        public AuthController(AppDBContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var admin = _context.Admins.FirstOrDefault(a => a.UserName == model.UserName && a.Password == model.Password);

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (admin == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid username or password.");
                return View(model);
            }

            //claims ==>  Kimlik kartı için kullanılır
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, admin.UserName),
                new Claim("fullName", admin.FullName)
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProps = new AuthenticationProperties
            {
                ExpiresUtc = DateTime.UtcNow.AddMinutes(30),
                IsPersistent = false
            };

            await HttpContext.SignInAsync
              (CookieAuthenticationDefaults.AuthenticationScheme,
              new ClaimsPrincipal(claimsIdentity), authProps);

            HttpContext.Session.SetString("fullName", admin.FullName);

            return RedirectToAction("Dashboard", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Remove("fullName");
            await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Default");
        }
    }
}
