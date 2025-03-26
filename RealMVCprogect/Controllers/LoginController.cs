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
		[HttpGet]
		public IActionResult Logo()
		{
			return View();
		}

		//	var exp = context.admins.FirstOrDefault(x=>x.AdminName == admin.AdminName && x.AdminPassword == admin.AdminPassword);

		////	var exp = context.admins.FirstOrDefault(x => x.AdminName == admin.AdminName && x.AdminPassword == admin.AdminPassword);

		//		ClaimsIdentity claim = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
		//		var properties = new AuthenticationProperties()
		//		{
		//			AllowRefresh = true,
		//			IsPersistent = admin.AdminName == admin.AdminName
		//		};

		//		HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claim));
		//		return RedirectToAction("Index", "AdminCategoryController1");
		//	}

		//	else
		//	{
		//	 return RedirectToAction("Index");
		//	}

		//}

	}
}
