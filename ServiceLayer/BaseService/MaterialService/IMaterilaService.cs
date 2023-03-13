using ShredKernal.Generics;
using ShredKernal.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.BaseService.MaterialService
{
    public interface IMaterilaService
    {

       Task< ApiResponse<bool>> UploadFile(UploadFileViewModel file);
    }
}
