﻿using cloudscribe.Pagination.Models;
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
    public interface IMaterilaService
    {

        Task<ApiResponse<bool>> UploadFile(UploadFileViewModel file);
        Task<List<MaterialViewModel>>GetAllMaterials();
        Task Delete(int id );
        Task<MaterialViewModel> GetCategoryWithMaterial(int catId);
    }
    
}
