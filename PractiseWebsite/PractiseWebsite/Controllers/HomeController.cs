using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PractiseWebsite.Models;
using PractiseWebsite.Repositorys.Models;
using PractiseWebsite.Services.Interface;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace PractiseWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductServices _productServices;
        private readonly NorthwindContext _northwindContext;

        public HomeController(ILogger<HomeController> logger, IProductServices productServices, NorthwindContext northwindContext)
        {
            _logger = logger;
            _productServices = productServices;
            _northwindContext = northwindContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "User")]
        public IActionResult Privacy()
        {
            return View();
        }

		[Authorize(Roles = "Admin")]
		public IActionResult Admin()
		{
			return View();
		}

		public decimal ProductId(int id)
        {
            var result = _productServices.GetProductById(id);

            return (decimal)result;
        }

        public List<CategorieModel> GetCategories(int id)
        {
            return _northwindContext.Categories.Select(c => new CategorieModel
            {
                categoryId = c.CategoryId,
                categoryName = c.CategoryName,
                product = c.Products.Select(p => new ProductModel
                {
                    productId = p.ProductId,
                    productName = p.ProductName
                }).ToList()
            }).ToList();
        }

        public IActionResult Send()
        {
            SmtpClient smtpClient = new SmtpClient();

            smtpClient.Host = "smtp.gmail.com";

            // Port
            smtpClient.Port = 587;
            smtpClient.EnableSsl = true;

            // 憑證 + 帳號、密碼 (需要到Google網頁上取得)
            smtpClient.Credentials = new NetworkCredential("JHobby.THM103@gmail.com", "hzin fmqu vxdi yexf");

            // 建立 (設定) MailMessage，如: 季送人、主旨、內容等
            var mail = new MailMessage();

            mail.Subject = "JHobby測試信";
            mail.From = new MailAddress("JHobby.THM103@gmail.com", "JHobby管理員");
            mail.To.Add("Guo1997tw@gmail.com");

            // 可以塞HTML or Image
            // 必需啟用IsBodyHTML = true設定，才可以用
            mail.Body = "<h1>會員測試信件</h1>";
            mail.IsBodyHtml = true;
            mail.BodyEncoding = Encoding.UTF8;

            try
            {
                smtpClient.Send(mail);

                return Content("成功");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}