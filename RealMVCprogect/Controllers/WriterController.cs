using BusinessLayer.Maneger;
using BusinessLayer.ValidationRele;
using DataAsseccLayer.EntityFramework;
using EntityLayer.Concreat;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RealMVCprogect.Controllers
{
    public class WriterController : Controller
    {
        WriterMeneger meneger = new WriterMeneger(new EfWriterDl());
        //WriterMeneger meneger = new WriterMeneger(new EfWriterDl());
        WriterValidation writervalidation = new WriterValidation();
    
        public IActionResult Index()
        {
            var WriterValues = meneger.GetList();
            return View(WriterValues);
        }
        [HttpGet]
        public IActionResult AddWriter()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddWriter(Writer writer)
        {  
            ValidationResult result = writervalidation.Validate(writer);
            if (result.IsValid)
            {
                meneger.WriterAddBl(writer);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
        }

        [HttpGet]
        public IActionResult UpdateWriter(int id)
        {
           var getId =  meneger.GetById(id);
            return View(getId);
        }

        [HttpPost]
        public IActionResult UpdateWriter(Writer writer)
        {
            ValidationResult result = writervalidation.Validate(writer);
            if (result.IsValid)
            {
                meneger.WriterUpdeteBL(writer);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
        }
    }
}
