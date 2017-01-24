using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProducts.Common
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Description { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public decimal StarRating { get; set; }

        public decimal Cost { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string ImageUrl { get; set; }
        public string[] Tags { get; set; }

        public Product()
        {
            Tags = new[] { "abc", "ad", "fg" };
        }
    }
}
