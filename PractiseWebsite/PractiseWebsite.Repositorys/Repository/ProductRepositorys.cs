using PractiseWebsite.Repositorys.Interface;
using PractiseWebsite.Repositorys.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PractiseWebsite.Repositorys.Repository
{
    public class ProductRepositorys : IProductRepositorys
    {
        private readonly NorthwindContext _northwindContext;

        public ProductRepositorys(NorthwindContext northwindContext)
        {
            _northwindContext = northwindContext;
        }

        public Product GetProductId(int id)
        {
            return _northwindContext.Products.FirstOrDefault(p => p.ProductId == id);
        }
    }
}