using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string CourseName  { get; set; }
        public Level Level { get; set; }
        public int LevelId { get; set; }
    }
}
