using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Project.Models;
using ServiceLayer.Service.MaterialService;
using ShredKernal.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMaterilaService materialService;
        private readonly INotyfService _notifyService;
        public HomeController(ILogger<HomeController> logger, Microsoft.AspNetCore.Hosting.IHostingEnvironment _ost, IMaterilaService mat, INotyfService notifyService)
        {
            materialService = mat;
            _logger = logger;
            _notifyService=notifyService;
            Host = _ost;
        }
        public Microsoft.AspNetCore.Hosting.IHostingEnvironment Host { get; }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> GetMaterilas()
        {
            var MaterialList =
                await materialService.GetAllMaterials();

            return View(MaterialList);
        }

        public async Task<IActionResult> GetCategoryWithMaterial(int catId)
        {
            var result = await materialService.GetCategoryWithMaterial(catId);
            return View(result);
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
        
        public async Task<IActionResult> Delete(int id)
        {

            await materialService.Delete(id);
             _notifyService.Warning("File is deleted");

            return RedirectToAction("GetMaterilas");
        }
        public async Task<FileResult> DownloadFile(string name)
        {


            string path = Path.Combine(Host.WebRootPath, "Material\\") + name;
            //it used to convert the file and download it 
            byte[] bytes = await System.IO.File.ReadAllBytesAsync(path);
            return File(bytes, "application/octet-stream", name);

        }





    }
}
