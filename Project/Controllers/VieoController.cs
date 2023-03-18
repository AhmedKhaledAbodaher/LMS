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

        public VideoController(VideoService videoService)
        {
            VideoService = VideoService;


        }
        public VideoService VideoService { get; set; }
        public Microsoft.AspNetCore.Hosting.IHostingEnvironment Host { get; }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> GetVideos()
        {
            

            return View();
        }

        public async Task<IActionResult> GetCategoryWithMaterial(int catId)
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
        public async Task<IActionResult> UploadFile(UploadVideoViewModel uploadedFile)
        {

         await  VideoService.UploadFile(uploadedFile);
            return View();
        }
        //public async Task<IActionResult> Delete(int id)
        //{

        //    await materialService.Delete(id);
        //    _notifyService.Warning("File is deleted");

        //    return RedirectToAction("GetMaterilas");
        //}
        //[HttpPost]
        public async Task<IActionResult> Delete(int id)
        {

            //await materialService.Delete(id);
            // _notifyService.Warning("File is deleted");

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
