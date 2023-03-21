using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShredKernal.ViewModels
{
    public class UploadFileViewModel
    {
        public string Name { get; set; }
        public string CtegoryName { get; set; }
        public string VideoDescription { get; set; }

        public IFormFile File { get; set; }
    }
}
