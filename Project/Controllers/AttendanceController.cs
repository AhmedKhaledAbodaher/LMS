using Microsoft.AspNetCore.Mvc;

namespace Project.Controllers
{
    public class AttendanceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
