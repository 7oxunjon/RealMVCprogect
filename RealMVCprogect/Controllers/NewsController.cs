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
        public NewsController(AppDbContext context)  // <-- Context konstruktor orqali keladi
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        NewsManager manager = new NewsManager(new EfNews());
        NewsValidation validations = new NewsValidation();
        public IActionResult Index()
        {
            var newsList = manager.GetList();
            return View(newsList);
        }

        [HttpPost]
        public async Task<IActionResult> UploadNews(int newsId, string title, string content, IFormFile[] files)
        {
            var news = _context.News.FirstOrDefault(n => n.Id == newsId);

            if (news != null)
            {
                // Yangilikni yangilash
                news.Title = title;
                news.Content = content;
                news.PublishDate = DateTime.Now;

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
            news.UserId = 1;
            manager.NewsAddBl(news);
            return RedirectToAction("Index");
            return View(news);
        }


    }
}
