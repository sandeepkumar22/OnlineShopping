using OnlineShopping.Database;
using OnlineShopping.Entities;
using OnlineShopping.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShopping.web.Controllers
{
    public class ProductController : Controller
    {
        Products productsService = new Products();
        // GET: Products
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ProductTable(string search)
        {
            var product = productsService.GetProducts();
            if(string.IsNullOrEmpty(search)==false)
            {
                product = product.Where(p => p.Name!=null && p.Name.ToLower().Contains(search.ToLower())).ToList();
            }
            return PartialView(product);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            productsService.SaveProduct(product);
            return RedirectToAction("ProductTable");
        }
    }
}