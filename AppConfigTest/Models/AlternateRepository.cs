using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppConfigTest.Models
{
    public class AlternateRepository : IRepository
    {
        private Dictionary<string, Product> products;
        private static int counter = 0;
        public int RepoCounter { get => counter; }
        public AlternateRepository()
        {
            products = new Dictionary<string, Product>();

            new List<Product>
            {
                new Product { Name = "Alt1", Price = 100m },
                new Product { Name = "Alt2", Price = 200m }
            }.ForEach(p => AddProduct(p));
        }
        public Product this[string name] => products[name];

        public IEnumerable<Product> Products => products.Values;

        public void AddProduct(Product product)
        {
            products[product.Name] = product;
        }

        public void DeleteProduct(Product product)
        {
            products.Remove(product.Name);
        }
    }
}
