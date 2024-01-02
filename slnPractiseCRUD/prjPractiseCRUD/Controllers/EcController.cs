using Microsoft.AspNetCore.Mvc;

namespace prjPractiseCRUD.Controllers
{
    public class EcController : Controller
    {
        public IActionResult List()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }
    }
}