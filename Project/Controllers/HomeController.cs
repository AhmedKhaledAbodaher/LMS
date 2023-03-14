using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project.Models;
using ServiceLayer.Service.MaterialService;
using ShredKernal.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMaterilaService materialService;

        public HomeController(ILogger<HomeController> logger, IMaterilaService mat)
        {
            materialService = mat;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetMaterilas()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult UploadFile()
        {


            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UploadFile(UploadFileViewModel uploadedFile)
        {
            if (ModelState.IsValid)
            {
           var response=   await  materialService.UploadFile(uploadedFile);
                ViewBag.cmdMessage = response.IsValidResponse;
                ViewBag.cmdMessage = response.CommandMessage;
            }
            
            return RedirectToAction("GetMaterilas", "Home");
        }
    }
}
