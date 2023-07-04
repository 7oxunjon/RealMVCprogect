using BusinessLayer.Maneger;
using DataAsseccLayer.EntityFramework;
using EntityLayer.Concreat;
using Microsoft.AspNetCore.Mvc;

namespace RealMVCprogect.Controllers
{
	public class GaleleriyaController : Controller
	{
		ImageFileManeger image = new ImageFileManeger(new EfImageFileDal());

		public IActionResult Index()
		{
			var files = image.GetList();
			return View(files);
		}
	}
}
