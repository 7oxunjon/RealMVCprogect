using BusinessLayer.Maneger;
using DataAsseccLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace RealMVCprogect.Controllers
{
    public class ContentController1 : Controller
    {
        ContentManager manager = new ContentManager(new EfContentDl());

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ContentByHeading(int id)
        {
            var con = manager.GetListByHeadingId(id);
            return View(con);
        }
    }
}
