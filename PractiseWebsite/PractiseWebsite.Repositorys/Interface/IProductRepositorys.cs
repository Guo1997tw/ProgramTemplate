using PractiseWebsite.Repositorys.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PractiseWebsite.Repositorys.Interface
{
    public interface IProductRepositorys
    {
        public Product GetProductId(int id);
    }
}