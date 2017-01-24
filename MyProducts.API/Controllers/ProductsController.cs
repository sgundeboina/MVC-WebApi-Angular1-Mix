using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Hosting;
using System.Web.Http;
using System.Web.Http.Description;
using MyProducts.Common;
using Newtonsoft.Json;

namespace MyProducts.API.Controllers
{
    public class ProductsController : ApiController
    {
        private List<Product> Products;
        public ProductsController()
        {
            var filepath = HostingEnvironment.MapPath("~/App_Data/product.json");
            var jsonContent = System.IO.File.ReadAllText(filepath);

            Products = JsonConvert.DeserializeObject<List<Product>>(jsonContent);

        }
        // GET: api/Products

        [ResponseType(typeof(Product))]
        public IHttpActionResult Get()
        {
            return Ok(this.Products.AsQueryable());
        }

        // GET: api/Products/5
        [ResponseType(typeof(Product))]
        public IHttpActionResult Get(int id)
        {
            var prd = this.Products.FirstOrDefault(x => x.ProductId == id);
            return Ok(prd);
        }

        // POST: api/Products
        public IHttpActionResult Post([FromBody]Product product)
        {
            var indx = this.Products.FindIndex(x => x.ProductId == product.ProductId);

            this.Products[indx] = product;

            WriteData();

            return Ok();
        }

        // PUT: api/Products/5
        [ResponseType(typeof(Product))]
        public IHttpActionResult Put(int productId, [FromBody]Product value)
        {
            var v = value;
            return Ok();
        }

        // DELETE: api/Products/5
        public void Delete(int id)
        {
        }

        internal void WriteData()
        {
            // Write out the Json
            var filePath = HostingEnvironment.MapPath(@"~/App_Data/product.json");

            var json = JsonConvert.SerializeObject(this.Products, Formatting.Indented);
            System.IO.File.WriteAllText(filePath, json);
        }
    }
}
