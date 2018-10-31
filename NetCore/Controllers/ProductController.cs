using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetCore.Models;

namespace NetCore.Controllers
{
    public class ProductController : Controller
    {

        private readonly MyDB _content;
       public ProductController(MyDB context)
        {
            _content = context;
        }
        public IActionResult GetList()
        {

            return View(_content.Products.ToList());
        }

        public IActionResult Create()
        {
           
            return View();
        }
        
        public IActionResult Save (Product product)
        {
            _content.Products.Add(product);
            _content.SaveChanges();
            TempData["message"] = "Create Success";
            return new RedirectResult("GetList");
        }

        public IActionResult Update(Product product)
        {
            var existProduct = _content.Products.Find(product.id);
            if (existProduct == null)
            {
                return NotFound();
            }
            existProduct.name = product.name;
            existProduct.price = product.price;
            _content.Products.Update(existProduct);
            _content.SaveChanges();
            TempData["message"] = "Update Success";
            return new RedirectResult("GetList");
        }
        public IActionResult Delete(int id)
        {
            var existProduct = _content.Products.Find(id);
            if (existProduct == null)
            {
                return NotFound();
            }
            _content.Products.Remove(existProduct);
            _content.SaveChanges();
            TempData["message"] = "Delete Success";
            return new RedirectResult("GetList");
        }
    }
}
