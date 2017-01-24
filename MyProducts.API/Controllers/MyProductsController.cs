using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyProducts.Common;
using Newtonsoft.Json;

namespace MyProducts.API.Controllers
{
    public class MyProductsController : Controller
    {
        public  List<Product> Products;
        public MyProductsController()
        {
           

        }
        // GET: MyProducts
        public ActionResult Index()
        {
            using (var client = new WebClient())
            {
                client.Headers.Add("content-type", "application/json");
                string response = client.DownloadString("http://localhost:59835/api/products");
                Products = JsonConvert.DeserializeObject<List<Product>>(response);

            }
            return View(Products);
        }

        public ActionResult Product(int id)
        {
            using (var client = new WebClient())
            {
                client.Headers.Add("content-type", "application/json");
                string response = client.DownloadString(string.Format("http://localhost:59835/api/products/{0}",id));
                return View(JsonConvert.DeserializeObject<Product>(response));
            }
            
        }

        [HttpPost]
        public ActionResult Product(int ProductId, Product value)
        {
            using (var client = new WebClient())
            {
                client.Headers.Add("content-type", "application/json");
                client.UploadString(string.Format("http://localhost:59835/api/products/{0}", ProductId), JsonConvert.SerializeObject(value));
                
            }
            
            return RedirectToAction("Index");
        }
    }
}