using BusinessLayer;
using BusinessLayer.ValidationRele;
using DataAsseccLayer.EntityFramework;
using EntityLayer.Concreat;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;



namespace RealMVCprogect.Controllers
{
    public class AdminCategoryController1 : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDl());

        [Authorize]
        public IActionResult Index()
        {
            var manager = categoryManager.GetList();
            return View(manager);
        }
        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCategory( Category category)
        {
            CategoryValidation rules = new CategoryValidation();
            ValidationResult result = rules.Validate(category);
            if (result.IsValid)
            {
                categoryManager.CategoryAddBL(category);
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

        public IActionResult DeleteCategory(int id)
        {
            var category = categoryManager.GetById(id);
            categoryManager.CategoryDeleteBL(category);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult YaratCategory(int id)
        {
            var categories = categoryManager.GetById(id);
            return View(categories);
        }
        [HttpPost]
        public IActionResult YaratCategory(Category p)
        {
            categoryManager.CategoryUpdateBL(p);
            return RedirectToAction("Index");
        }

    }
}
