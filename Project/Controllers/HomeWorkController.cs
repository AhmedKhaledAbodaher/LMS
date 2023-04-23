using AspNetCoreHero.ToastNotification.Abstractions;
using DomainLayer.Models;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Service.CourceService;
using ServiceLayer.Service.MaterialService;
using ShredKernal.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc.Html;


namespace Project.Views.Attendance
{
    public class HomeWorkController : Controller
    {
        public ILevelService LevelService { get;  }
        public ICourseService  CourseService { get;  }
        private readonly INotyfService _notifyService;

        public HomeWorkController( ICourseService service,ILevelService level, INotyfService notyf)
        {
            LevelService = level;   
            CourseService = service; 
            _notifyService=notyf;
        }
     
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await LevelService.GetAllLevels();
            LevelViewModel level = new LevelViewModel();
            //ViewBag.cf = new System.Collections.Generic.List<DomainLayer.Models.CourseFiles>() {
            //    new DomainLayer.Models.CourseFiles() { FileName = "aaa" },
            //    new DomainLayer.Models.CourseFiles() { FileName = "aaa" },
            //    new DomainLayer.Models.CourseFiles() { FileName = "aaa" },
            //    new DomainLayer.Models.CourseFiles() { FileName = "aaa" },
            //    new DomainLayer.Models.CourseFiles() { FileName = "aaa" }


            //};
            level = new LevelViewModel() { Levels = result };
           
            return View(level);
        }
        [HttpPost]
        public async Task<IActionResult> Index(int courseId)
        {
            List<Level> result=new List<Level> (){ };
            LevelViewModel level = new LevelViewModel();
            if (courseId != default(int))
            {
                result = await LevelService.GetAllLevels();
                var courcesFile = await CourseService.GetCoursesFiles(courseId);
                level = new LevelViewModel() { CourseFiles = courcesFile ,Levels=result};
                ViewBag.cf = level.CourseFiles;
            }
            else {
                 result = await LevelService.GetAllLevels();            
                level = new LevelViewModel() { Levels = result };
            }
            return View(level);
        }
        
       
        public async Task< IActionResult> GetCources(int levelId)
        {
            var cources = await CourseService.GetCourses(x=>x.LevelId==levelId);
            return Ok(cources);
        }

        //public async Task<IActionResult> GetCourcesFiles(int courseId)
        //{
        //    var courcesFile = await CourseService.GetCoursesFiles(courseId);
        //    LevelViewModel levelViewModel = new LevelViewModel() { CourseFiles =courcesFile};
        //    return Json(levelViewModel);
        //} 
        [HttpGet]

        public async Task<IActionResult> GetCourcesFiles(int courseId)
        {
            var courcesFile = await CourseService.GetCoursesFiles(courseId);
            
            return View(courcesFile);
        }
        public async Task<IActionResult> UploadFile()
        {


            var result =  await LevelService.GetAllLevels();
            UploadCourseFileViewModel level = new UploadCourseFileViewModel() { Levels = result };
          
            ViewBag.level = level;
            return View(level);
        }
        [HttpPost]
        public async Task<IActionResult> UploadFile(UploadCourseFileViewModel uploadedFile)
        {
            var result = await LevelService.GetAllLevels();
            UploadCourseFileViewModel level = new UploadCourseFileViewModel() { Levels = result };
           

            if (ModelState.IsValid)
            {
                var response = await CourseService.UploadFile(uploadedFile);
                _notifyService.Success("Uploaded");
            }

            return View(level);
        }
    }
}
