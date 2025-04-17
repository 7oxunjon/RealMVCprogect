using BusinessLayer.Maneger;
using BusinessLayer.ValidationRele;
using DataAsseccLayer.Concreat;
using DataAsseccLayer.EntityFramework;
using EntityLayer.Concreat;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace RealMVCprogect.Controllers
{
    public class NewsController : Controller
    {
        private readonly AppDbContext _context;
        private static int _id;

        public NewsController(AppDbContext context)  // <-- Context konstruktor orqali keladi
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            var isUser = _context.Users.FirstOrDefault(n => n.Name == CurrentUser.UserName);
            _id = isUser.id;
        }
        NewsManager manager = new NewsManager(new EfNews());
        NewsValidation validations = new NewsValidation();
        public IActionResult Index()
        {
            var newsList = manager.GetList();
            return View(newsList);
        }

        [HttpPost]
        public async Task<IActionResult> UploadNews(int newsId, string title, string content, int status, IFormFile[] files)
        {
            var news = _context.News.FirstOrDefault(n => n.Id == newsId);
           

            if (news != null)
            {
                // Yangilikni yangilash
                news.Title = title;
                news.Content = content;
                news.PublishDate = DateTime.Now;
                news.status = status;
                if (files != null && files.Length > 0)
                {
                    // Eski rasmni o'chirish
                    if (!string.IsNullOrEmpty(news.photoNews))
                    {
                        var oldImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", news.photoNews.TrimStart('/'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath); // Eski rasmni o'chirish
                        }
                    }

                    // Yangi rasmni saqlash
                    var file = files[0];  // Birinchi faylni olish
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", file.FileName);

                    // Faylni yuklash
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    // Rasm yo'lini yangilash
                    news.photoNews = $"/uploads/{file.FileName}";
                }

                // Yangilangan ma'lumotlarni saqlash
                _context.News.Update(news);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DeleteNews(int Id)
        {
            var getdate = manager.GetById(Id);
            return View(getdate);
        }

        [HttpPost]

        public IActionResult ConfirmDeleteNews(int newsId)
        {
            var news = manager.GetById(newsId);
            if (news == null)
            {
                TempData["Error"] = "Янгилик топилмади.";
                return RedirectToAction("Index");
            }

            // Rasming yo‘lini aniqlash
            if (!string.IsNullOrEmpty(news.photoNews))
            {
                string rootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
                string imagePath = Path.Combine(rootPath, news.photoNews.TrimStart('/').Replace("/", Path.DirectorySeparatorChar.ToString()));

                // Agar fayl mavjud bo‘lsa - o‘chiramiz
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
            }

            // Yangilikni bazadan o‘chirish
            manager.NewsDeleteBl(news);

            TempData["Success"] = "Янгилик ва расм муваффақиятли ўчирилди.";
            return RedirectToAction("Index");
           

        }

        [HttpGet]
        public IActionResult GetByIdNew(int Id)
        {
            var getId = manager.GetById(Id);
            return View(getId);
        }


        [HttpGet]
        public IActionResult AddNews()
        {
            return View();
        }



        [HttpPost]
        public IActionResult AddNews(News news, IFormFile files)
        {
            if (news == null)
                return View();
            if (files != null && files.Length > 0)
            {
                var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(files.FileName);
                var savePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", uniqueFileName);
                using (var stream = new FileStream(savePath, FileMode.Create))
                {
                    files.CopyTo(stream);
                }
                news.photoNews = "/uploads/" + uniqueFileName;
            }
            news.PublishDate = DateTime.Now;
            news.PublishDate = DateTime.Now;
            news.UserId = _id;
            manager.NewsAddBl(news);
            return RedirectToAction("Index");
            return View(news);
        }


    }
}
