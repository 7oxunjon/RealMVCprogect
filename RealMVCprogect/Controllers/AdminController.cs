using BusinessLayer.Maneger;
using DataAsseccLayer.EntityFramework;
using EntityLayer.Concreat;
using Microsoft.AspNetCore.Mvc;

namespace RealMVCprogect.Controllers
{
    public class AdminController : Controller
    {
        UsersManeger usersManeger = new UsersManeger(new EfUserDl());

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]

        public IActionResult AddUsers(Users users)
        {
            usersManeger.UsersAddBl(users);
            return RedirectToAction("Index");
        }
    }
}
