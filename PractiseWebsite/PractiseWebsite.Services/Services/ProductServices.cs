using PractiseWebsite.Repositorys.Interface;
using PractiseWebsite.Repositorys.Models;
using PractiseWebsite.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PractiseWebsite.Services.Services
{
    public class ProductServices : IProductServices
    {
        private readonly IProductRepositorys _productRepositorys;

        public ProductServices(IProductRepositorys productRepositorys)
        {
            _productRepositorys = productRepositorys;
        }

        public decimal GetProductById(int id)
        {
            var result = _productRepositorys.GetProductId(id);

            return (decimal)(0.8m * result.UnitPrice);
        }
    }
}