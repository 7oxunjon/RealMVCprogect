using BusinessLayer.Maneger;
using DataAsseccLayer.Concreat;
using DataAsseccLayer.EntityFramework;
using EntityLayer.Concreat;
using Microsoft.AspNetCore.Mvc;

namespace RealMVCprogect.Controllers
{
    public class AdminController : Controller
    {
        UsersManeger usersManeger = new UsersManeger(new EfUserDl());
        private readonly AppDbContext _ctx;
        public AdminController(AppDbContext appDbContext)
        {
            _ctx = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext));
        }
        public IActionResult Index()
        {
            var user = _ctx.Users.FirstOrDefault(u=>u.Name==CurrentUser.UserName);
            if (user!=null)
            {
                return View(user);
            }
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
