using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppConfigTest.Models
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }
        void AddProduct(Product product);
    }
    public class ProductRepository : IProductRepository
    {
        private List<Product> products = new List<Product>
        {
            new Product { Name = "iPhone 7", Price = 1000m },
            new Product { Name = "iPhone 8", Price = 1200m },
            new Product { Name = "iPhone 9", Price = 1400m }
        };
        public IEnumerable<Product> Products => products;

        public void AddProduct(Product product)
        {
            products.Add(product);
        }
    }
}
