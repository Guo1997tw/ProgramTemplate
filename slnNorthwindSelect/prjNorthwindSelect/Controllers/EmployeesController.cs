using Microsoft.AspNetCore.Mvc;

namespace prjNorthwindSelect.Controllers
{
    public class EmployeesController : Controller
    {
        public IActionResult InsertEmployees()
        {
            return View();
        }
    }
}