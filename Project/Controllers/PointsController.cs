using Microsoft.AspNetCore.Mvc;

namespace Project.Controllers
{
    public class PointsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
