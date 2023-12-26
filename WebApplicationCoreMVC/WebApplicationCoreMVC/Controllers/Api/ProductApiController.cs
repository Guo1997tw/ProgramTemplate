using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationCoreMVC.Models;

namespace WebApplicationCoreMVC.Controllers.Api
{
    [Route("api/Product/[action]")]
    [ApiController]
    public class ProductApiController : ControllerBase
    {
        public List<ProductForNewsViewModel> News()
        {
            return new List<ProductForNewsViewModel>()
            {
                new ProductForNewsViewModel{ProductID=1, UnitPrice=99.8M, ProductName="泡麵", },
                new ProductForNewsViewModel{ProductID=2, UnitPrice=91, ProductName="炒飯"},
                new ProductForNewsViewModel{ProductID=3, UnitPrice=22.8M, ProductName="泡麵"},
                new ProductForNewsViewModel{ProductID=4, UnitPrice=30, ProductName="三明治"},
                new ProductForNewsViewModel{ProductID=5, UnitPrice=50.8M, ProductName="咖啡"}
            };
        }
    }
}