using BusinessLayer.Maneger;
using DataAsseccLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace RealMVCprogect.Controllers
{
    public class Test_newsController : Controller
    {
        NewsManager manager = new NewsManager(new EfNews());
        public IActionResult Index()
        {
            var gettestNews = manager.GetList();
            return View(gettestNews);
        }
    }
}
