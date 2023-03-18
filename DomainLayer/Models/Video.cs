using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class Video
    {
        public int Id { get; set; }
        public string VideoName { get; set; }
        public string VideoUrl { get; set; }
        public Genre Genre { get; set; }
        public int GenreId { get; set; }

    }
}
