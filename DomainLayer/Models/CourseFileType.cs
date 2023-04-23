using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class CourseFileType
    {
        public int Id { get; set; }
        public string CourseType { get; set; }
        public ICollection<CourseFiles> CourseFiles { get; set; }
    }
}
