using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Service.CourceService;
using ServiceLayer.Service.MaterialService;
using ShredKernal.ViewModels;
using System.Threading.Tasks;

namespace Project.Views.Attendance
{
    public class HomeWorkController : Controller
    {
        public ILevelService LevelService { get;  }
        public ICourseService  CourseService { get;  }
        public HomeWorkController( ICourseService service,ILevelService level)
        {
            LevelService = level;   
            CourseService = service;
        }
        public async Task< IActionResult> Index()
        {
            var result = await LevelService.GetAllLevels();
            LevelViewModel level=new LevelViewModel() { Levels= result };
            return View(level);
        }
        public async Task< IActionResult> GetCources(int levelId)
        {
            var cources = await CourseService.GetCourses(x=>x.LevelId==levelId);
            return Ok(cources);
        }

    }
}
