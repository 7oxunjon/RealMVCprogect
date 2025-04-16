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

        public IActionResult AddUser()
        {
            return View();
        }
        [HttpPost]
        public JsonResult CheckPassword(string password)
        {
            var users = usersManeger.GetList();
            bool isExists = users.Any(u => u.PasswordHash == password);
            return Json(new { exists = isExists });
        }

        [HttpPost]
        public JsonResult CheckName(string name)
        {
            var users = usersManeger.GetList();
            bool isExists = users.Any(u => u.Name == name);
            return Json(new { exists = isExists });
        }

        [HttpPost]
        public JsonResult CheckEmail(string email)
        {
            var users = usersManeger.GetList();
            bool isExists = users.Any(u => u.Email == email);
            return Json(new { exists = isExists });
        }

        [HttpPost]
        public IActionResult AddUsers(Users users)
        {
            users.CreatedAt = DateTime.Now;
            usersManeger.UsersAddBl(users);
            return RedirectToAction("Index");
            return View(users);
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


        [HttpGet]

        public IActionResult UserDelete(int Id)
        {
            var GetId = usersManeger.GetById(Id);
            return View(GetId);
        }

        [HttpPost]
        public IActionResult UserDelete(Users users)
        {
            try
            {
                usersManeger.UsersDeleteBl(users);
                return RedirectToAction("Index");
                    
            }
            catch (Exception)
            {
                TempData["Error"] = "❌ Foydalanuvchi topilmadi yoki o‘chirishda xatolik yuz berdi.";
                return RedirectToAction("Index");
            }
        }
    }
}
