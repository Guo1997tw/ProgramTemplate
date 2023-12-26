using PractiseWebsite.Repositorys.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PractiseWebsite.Services.Interface
{
    public interface IProductServices
    {
        public decimal GetProductById(int id);
    }
}