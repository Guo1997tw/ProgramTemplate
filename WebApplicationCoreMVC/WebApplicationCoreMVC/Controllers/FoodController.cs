using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using WebApplicationCoreMVC.Models;

namespace WebApplicationCoreMVC.Controllers
{
    public class FoodController : Controller
    {
        public IActionResult Category()
        {
            var result = new List<string> { "羅宋麵包", "咖哩飯", "珍珠奶茶", "水餃", "牛肉麵" };

            ViewBag.Data = result;

            return View();
        }

        public IActionResult DemoApi()
        {
            string connectionString =
                "Data Source=LAPTOP-EGI1T3KO;Initial Catalog=Northwind;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

            string queryString =
                             @"SELECT ProductID, UnitPrice, ProductName from dbo.products 
                               WHERE UnitPrice > @pricePoint
                               ORDER BY UnitPrice DESC";

            List<ProductsViewModel> productsList = new List<ProductsViewModel>();

            using (Microsoft.Data.SqlClient.SqlConnection connection = new Microsoft.Data.SqlClient.SqlConnection(connectionString))
            {
                Microsoft.Data.SqlClient.SqlCommand command = new Microsoft.Data.SqlClient.SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@pricePoint", 100);

                try
                {
                    connection.Open();
                    Microsoft.Data.SqlClient.SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        ProductsViewModel products = new ProductsViewModel();

                        products.ProductID = (int)reader[0];
                        products.UnitPrice = (decimal)reader[1];
                        products.ProductName = (string)reader[2];

                        productsList.Add(products);
                    }
                    reader.Close();
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                var result = productsList.Where(x => x.ProductName.Contains("yu")).ToList();

                foreach (var r in result)
                {
                    Console.WriteLine(r.ProductName);
                }

                ViewBag.Data = result;
            }

            return View();
        }
        
        public IActionResult VueDemo()
        {
            return View();
        }
    }
}