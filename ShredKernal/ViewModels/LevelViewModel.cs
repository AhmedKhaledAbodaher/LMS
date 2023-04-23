using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShredKernal.ViewModels
{
    public class LevelViewModel
    {
        public int LevelId { get; set; }
        public int CourselId { get; set; }
        public List<Level> Levels { get; set; }
        public List<Course> Courses { get; set; } = new List<Course>();
        public List<CourseFiles> CourseFiles { get; set; } = new List<CourseFiles>();
    }
}
