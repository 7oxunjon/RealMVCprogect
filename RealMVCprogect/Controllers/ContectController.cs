using BusinessLayer.Maneger;
using BusinessLayer.ValidationRele;
using DataAsseccLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace RealMVCprogect.Controllers
{
    public class ContectController : Controller
    {
       ContactMenager contect = new ContactMenager(new EfContactDl());
        ContectValidator validator = new ContectValidator();    
        
        public IActionResult Index()
        {
            var contectval = contect.GetList();
            return View(contectval);
        }

        public IActionResult GetContectDetails(int Id)
        {
            var contectvalue = contect.ContactById(Id);
            return View(contectvalue);

        }

        public PartialViewResult MessageListMenyu()
        {
            return PartialView();
        }
    }
}
