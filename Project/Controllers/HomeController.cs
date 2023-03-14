using AspNetCoreHero.ToastNotification.Abstractions;
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
        private readonly INotyfService _notifyService;
        public HomeController(ILogger<HomeController> logger, IMaterilaService mat, INotyfService notifyService)
        {
            materialService = mat;
            _logger = logger;
            _notifyService=notifyService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetMaterilas()
        {
           
            return View(materialService.GetAllMaterials());
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
                //ViewBag.IsValidResponse = response.IsValidResponse;
                //ViewBag.cmdMessage = response.CommandMessage;
                _notifyService.Success($"New File Added");

            }

            return View();
        }
    }
}
