using BusinessLayer.Maneger;
using DataAsseccLayer.EntityFramework;
using EntityLayer.Concreat;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace RealMVCprogect.Controllers
{
    public class UsersController : Controller
    {
        UsersManeger usersManeger = new UsersManeger(new EfUserDl());

        public IActionResult Index()
        {
            var UserValue = usersManeger.GetList();
            return View(UserValue);
        }
        [HttpGet]
        public IActionResult UpdateUsers(int Id)
        {
            var gerId = usersManeger.GetById(Id);
            return View(gerId);
        }

        [HttpPost]

        public IActionResult UpdateUsers(Users users)
        {
            users.CreatedAt = DateTime.Now;
            usersManeger.UsersUpdateBl(users);
            return RedirectToAction("Index");
        }
    }
}
