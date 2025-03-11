using Microsoft.AspNetCore.Mvc;

namespace RealMVCprogect.Controllers
{
    public class AdminController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
