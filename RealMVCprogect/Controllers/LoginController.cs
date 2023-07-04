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
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Index(Admin admin)
		{
			var context = new AppDbContext();

			var exp = context.admins.FirstOrDefault(x=>x.AdminName == admin.AdminName && x.AdminRole == admin.AdminRole);

			if(exp != null)
			{
				List<Claim> claims = new List<Claim>()
				{
				new Claim(ClaimTypes.Name, admin.AdminName),
				new Claim(ClaimTypes.UserData, admin.AdminPassword)
				};

				ClaimsIdentity claim = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
				//var properties = new AuthenticationProperties()
				//{
				//	AllowRefresh = true,
				//	IsPersistent = admin.AdminName == admin.AdminName
				//};

				HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claim));

				return RedirectToAction("Index", "AdminCategoryController1");
			}

			else
			{
			 return RedirectToAction("Index");
			}

		}

	}
}
