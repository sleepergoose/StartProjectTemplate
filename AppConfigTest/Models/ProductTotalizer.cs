using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppConfigTest.Models
{
    public class ProductTotalizer
    {
        public IRepository Repository { get; set; }

        public ProductTotalizer(IRepository repo)
        {
            Repository = repo;
        }

        public decimal Total => Repository.Products.Sum(p => p.Price);
    }
}
