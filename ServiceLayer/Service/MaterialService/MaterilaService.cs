using AutoMapper;
using DomainLayer.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Repository.IRepo;
using Repository.Repo;
using RepositoryLayer.UnitOfWork;
using ServiceLayer.Service.BaseService;
using ShredKernal.Generics;
using ShredKernal.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Service.MaterialService
{
    public class MaterilaService : BaseAppService, IMaterilaService
    {
        #region CTOR
        public MaterilaService(IConfiguration configuration, IMaterialRepository material,
               IUnitOfWork unitOfWork, IMapper mapper) : base(
                    unitOfWork, mapper)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            Material = material;
        }
        public IMapper Mapper { get; set; }
        public IUnitOfWork UnitOfWork { get; }
        public IMaterilaService Materila { get; }
        public IMaterialRepository Material { get; }
        public IHostingEnvironment Host { get; }
        #endregion

        public async Task<ApiResponse<bool>> UploadFile(UploadFileViewModel file)
        {
            #region Declare Return Value
            ApiResponse<bool> response = new ApiResponse<bool>();
            #endregion



            string UniqueFileNane = default;
            if (file.File is not null)
            {
                string UploaderFolder = Path.Combine(Host.WebRootPath, "Material");
                UniqueFileNane = Guid.NewGuid().ToString() + "_" + file.File.FileName;
                string FilePaht = Path.Combine(UploaderFolder, UniqueFileNane);
                //it uses the path to create it into the desk 
                file.File.CopyTo(new FileStream(FilePaht, FileMode.Create));

            }
            Material material = new Material
            {
                FileName = file.Name,
                FilePath = UniqueFileNane,
                Category = new Category()
                {
                    CategoryName = file.CtegoryName
                }
            };
            await Material.InsertAsync(material);
            bool isSuccess = await UnitOfWork.SaveChangesAsync();
            if (isSuccess)
            {
                await UnitOfWork.SaveChangesAsync();
                response.IsValidResponse = true;
                //to Add MessageResourceReader with its layers
                response.CommandMessage = "File Added Successfully ";
            }
            return response;
        }
    }
}
