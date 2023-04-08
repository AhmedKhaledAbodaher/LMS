using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShredKernal.ViewModels
{
    public class UploadCourseFileViewModel: UploadFileViewModel
    {
        public int LevelId { get; set; }
        public List<Level> Levels { get; set; }=new List<Level>();
    }
}
