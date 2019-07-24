using OnlineShopping.Services;
using OnlineShopping.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShopping.web.Controllers
{
    public class CategoryController : Controller
    {
        CategoriesService categoriesService =new CategoriesService();

        public ActionResult Index()
        {
            var categories= categoriesService.GetCategories();
            return View(categories);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Category category)
        {
            categoriesService.SaveCategory(category);
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int ID)
        {
            var categoy = categoriesService.GetCategory(ID);
            return View(categoy);
        }

        [HttpPost]
        public ActionResult Edit(Category category)
        {
            categoriesService.updateCategory(category);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int ID)
        {
            var category = categoriesService.GetCategory(ID);
            return View(category);
        }

        [HttpPost]
        public ActionResult Delete(Category category)
        {
            categoriesService.deleteCategory(category.ID);
            return RedirectToAction("Index");
        }
    }
}