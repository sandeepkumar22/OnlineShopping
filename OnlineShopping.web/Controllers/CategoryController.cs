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
    }
}