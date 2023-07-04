using BusinessLayer;
using BusinessLayer.Maneger;
using DataAsseccLayer.EntityFramework;
using EntityLayer.Concreat;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RealMVCprogect.Controllers
{
    public class HeadingController : Controller
    {
        HeadingManager hm = new HeadingManager(new EfHeadingDl());
        CategoryManager cm = new CategoryManager( new EfCategoryDl());
        WriterMeneger wm = new WriterMeneger(new EfWriterDl());

        public IActionResult Index()
        {
            var heading = hm.GetList();
            return View(heading);
        }

        [HttpGet]
        public IActionResult AddHeading()
        {
            var categoryvalue = (from x in cm.GetList()
                         select new SelectListItem
                         {
                             Text = x.CotegoryName,
                             Value = x.CotegoryId.ToString()
                         });
            List<SelectListItem> value = categoryvalue.ToList();

            var writervalue = (from x in wm.GetList()
                               select new SelectListItem
                               {
                                   Text = x.WriterName,
                                   Value = x.WriterId.ToString()
                               }
                               );
            List<SelectListItem> val = writervalue.ToList();
            ViewBag.wv = val;
            ViewBag.vlc = value;
            return View();
        }

        [HttpPost]
        public IActionResult AddHeading(Heading heading)
        {

            DateTime data = DateTime.UtcNow;
            DateTime Utcdata = DateTime.SpecifyKind(data, DateTimeKind.Utc);    
            heading.HeadingDate = Utcdata;
            hm.HeadingAddBl(heading);
            return RedirectToAction("Index");
        }

        public IActionResult EditHeading(int id)
        {
            var categoryvalue = (from x in cm.GetList()
                                 select new SelectListItem
                                 {
                                     Text = x.CotegoryName,
                                     Value = x.CotegoryId.ToString()
                                 });
            List<SelectListItem> value = categoryvalue.ToList();

            ViewBag.vlc = value;
            

            var headingValue = hm.GetById(id);
            return View(headingValue);
        }

        [HttpPost]
        public IActionResult EditHeading(Heading p)
        {
            DateTime data = DateTime.UtcNow;
            DateTime Utcdata = DateTime.SpecifyKind(data, DateTimeKind.Utc);
            p.HeadingDate = Utcdata;
            hm.HeadingUpdateBl(p);
            return RedirectToAction("Index");

        }

        public IActionResult DeleteHeading(int id)
        {
            var delete = hm.GetById(id);
            delete.Headingstatus = false;
                hm.HeadingDeleteBl(delete);
            return RedirectToAction("Index");
        }
    }
}
