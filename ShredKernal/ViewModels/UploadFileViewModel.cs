using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShredKernal.ViewModels
{
    public class UploadVideoViewModel
    {
        public string Name { get; set; }
        public string GenreName { get; set; }
        public string VideoDescription { get; set; }

        public string VideoUrl { get; set; }
    }
}
