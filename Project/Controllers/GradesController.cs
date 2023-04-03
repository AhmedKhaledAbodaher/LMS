using Microsoft.AspNetCore.Mvc;

namespace Project.Controllers
{
    public class GradesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
