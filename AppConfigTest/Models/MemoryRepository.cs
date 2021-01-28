using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppConfigTest.Models
{
    public class MemoryRepository : IRepository
    {
        private IModelStorage storage;
        private static int counter = 0;
        private string guid = System.Guid.NewGuid().ToString();
        public int RepoCounter { get => counter; }

        public override string ToString()
        {
            return guid;
        }

        public MemoryRepository(IModelStorage strg)
        {
            counter++;
            storage = strg;

            new List<Product>
            {
                new Product { Name = "Kayak", Price = 275M },
                new Product { Name = "Lifejacket", Price = 48.95M },
                new Product { Name = "Soccer ball", Price = 19.50M }
            }.ForEach(p => AddProduct(p));
        }

        public Product this[string name]
        {
            get
            {
                return storage[name];
            }
        }

        public IEnumerable<Product> Products => storage.Items;

        public void AddProduct(Product product)
        {
            storage[product.Name] = product; 
        }

        public void DeleteProduct(Product product)
        {
            storage.RemoveItem(product.Name);
        }
    }
}
