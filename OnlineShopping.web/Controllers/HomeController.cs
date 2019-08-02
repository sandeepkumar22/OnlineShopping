﻿using OnlineShopping.web.ViewModels;
using OnlineShopping.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShopping.web.Controllers
{
    public class HomeController : Controller
    {
        CategoriesService categoriesService = new CategoriesService();
        public ActionResult Index()
        {
            HomeViewModels model = new HomeViewModels();
            model.Categories = categoriesService.GetCategories();
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}