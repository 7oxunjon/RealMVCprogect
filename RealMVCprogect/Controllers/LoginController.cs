using DataAsseccLayer.Concreat;
using EntityLayer.Concreat;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace RealMVCprogect.Controllers
{
    public class LoginController : Controller
    {
        private readonly AppDbContext _appDbContext;
        public LoginController(AppDbContext appDb)
        {
            _appDbContext = appDb ?? throw new ArgumentNullException(nameof(appDb));
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]

        public IActionResult Index(string Name, string PasswordHash)
        {
            var user = _appDbContext.Users.FirstOrDefault(u => u.PasswordHash == PasswordHash);
            if (user != null)
            {
                if (user.Position == "Admin")
                {
                    CurrentUser.UserName = user.Name;
                    CurrentUser.id = user.id;
                    TempData["Success"] = "Tizimga muvaffaqiyatli kirdingiz.";
                    return RedirectToAction("Index", "Admin"); 
                }
                else
                {
                    ViewBag.Error = "Siz Admin emassiz, tizimga kira olmaysiz.";
                    return View();
                }
            }
            else
            {
                ViewBag.Error = "Foydalanuvchi topilmadi yoki parol noto‘g‘ri.";
                return View();
            }

        }
        public async Task<IActionResult> Logout()
        {
            // Tizimdan chiqish (cookie ni o'chirish)
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            // Chiqishdan keyin qayta login sahifasiga o'tish
            return RedirectToAction("Index", "Login");
        }
    }
}
