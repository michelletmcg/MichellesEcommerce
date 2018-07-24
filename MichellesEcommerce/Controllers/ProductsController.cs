using MichellesEcommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MichellesEcommerce.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        [HttpGet]
        public ActionResult Index()
        {
            //should show user list of all products
            List<Product> prods = ProductDB.GetAllProducts();
            return View(prods); //modelbind to all  the different products

            //same as above in 1 statement
            //return View(ProductDB.GetAllProducts());
        }
        /// <summary>
        /// returns web page to allow creation of products
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            //runs validation code (from data annotations in the Model)
            if (ModelState.IsValid)
            {
                ProductDB.AddProduct(product);
                return RedirectToAction("Index"); //sends you back to the index page
            }
            //showing the user the same web page with error messages
            //return view with model and invalid ModelState
            return View(product);
        }
    }
}