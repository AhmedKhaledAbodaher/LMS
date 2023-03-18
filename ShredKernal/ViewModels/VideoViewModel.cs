using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShredKernal.ViewModels
{
    public class VideoViewModel
    {
    
        public ICollection<Video> Videos { get; set; }
        public string GenreName { get; set; }

    }
}
