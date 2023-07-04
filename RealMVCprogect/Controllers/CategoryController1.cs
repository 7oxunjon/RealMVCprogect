using BusinessLayer;
using BusinessLayer.ValidationRele;
using DataAsseccLayer.EntityFramework;
using EntityLayer.Concreat;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace RealMVCprogect.Controllers
{
    public class CategoryController1 : Controller
    {
        CategoryManager manager = new CategoryManager(new EfCategoryDl());

      
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetCategoryList()
        {
            if (manager != null)
            {
              var category = manager.GetList();
              return View(category);
            }
            else { return View(); }
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            //manager.CategoryAddBL(category);
            CategoryValidation rules = new CategoryValidation();
            ValidationResult result = rules.Validate(category);
            if (result.IsValid)
            {
                manager.CategoryAddBL(category);
                return RedirectToAction("GetCategoryList");
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

        //[HttpPost]
        //public IActionResult AddCategory(Category category)
        //{
        //    CategoryValidation rules = new CategoryValidation();
        //    ValidationResult result = rules.Validate(category);
        //    if (result.IsValid)
        //    {
        //        manager.CategoryAddBL(category);
        //        return RedirectToAction("GetCategoryList");
        //    }
        //    else
        //    {
        //        foreach (var item in result.Errors)
        //        {
        //            ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
        //        }
        //    }
        //    return View();
        //}

        

    }
}
