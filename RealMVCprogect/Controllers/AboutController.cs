using BusinessLayer.Maneger;
using DataAsseccLayer.EntityFramework;
using EntityLayer.Concreat;
using Microsoft.AspNetCore.Mvc;


namespace RealMVCprogect.Controllers
{
    public class AboutController : Controller
    {

        AboutManager manager = new AboutManager(new EfAboutDl());
        public IActionResult Index()
        {
            var getvalue = manager.GetList();
            return View(getvalue);
        }

        [HttpPost]
        public IActionResult AddAbout(About about)
        {
            manager.AboutAdd(about);
            return RedirectToAction("Index");
        }

        public PartialViewResult AboutPartial()
        {
            Console.WriteLine(  );
            return PartialView();
        }
    }
}
