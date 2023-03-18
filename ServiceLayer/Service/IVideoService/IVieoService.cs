using cloudscribe.Pagination.Models;
using Microsoft.AspNetCore.Mvc;
using ShredKernal.Generics;
using ShredKernal.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Service.MaterialService
{
    public interface IVieoService
    {
        Task<ApiResponse<bool>> UploadFile(UploadVideoViewModel file);



    }

}
