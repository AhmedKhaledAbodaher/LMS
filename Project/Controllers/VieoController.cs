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
    public class VideoController : Controller
    {

        public VideoController(IVieoService videoService, INotyfService notyf, INotyfService notifyService)
        {
            VideoService = videoService;

            Notyf = notyf;
            _notifyService = notifyService; 
        }
        public IVieoService VideoService { get; set; }
        private readonly INotyfService _notifyService;

        public Microsoft.AspNetCore.Hosting.IHostingEnvironment Host { get; }
        public INotyfService Notyf { get; set; }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> GetVideos()
        {
            //VideoService.get
            var result =await VideoService.GetVideos();
            return View(result);
        }

        public async Task<IActionResult> GetVideoWithGenre(int catId)
        {
           
            return View(await VideoService.GetVideoWithGenre(catId));
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
        public async Task<IActionResult> UploadFile(UploadVideoViewModel uploadedFile)
        {
            if (ModelState.IsValid)
            {
                await VideoService.UploadFile(uploadedFile);
                //_notifyService.Success($"New File Added");
                Notyf.Success("New Video Uploded ");
            }
            return View();
        }
       
        public async Task<IActionResult> Delete(int id)
        {

            await VideoService.Delete(id);
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
