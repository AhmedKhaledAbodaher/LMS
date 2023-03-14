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
        public MaterilaService(IConfiguration configuration, ICategoryRepository cat, IHostingEnvironment _ost, IMaterialRepository material,
               IUnitOfWork unitOfWork, IMapper mapper) : base(
                    unitOfWork, mapper)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            Material = material;
            Host = _ost;
            Category = cat;

        }
        public IMapper Mapper { get; set; }
        public IUnitOfWork UnitOfWork { get; }
        public IMaterilaService Materila { get; }
        public IMaterialRepository Material { get; }
        public ICategoryRepository Category { get; }
        public IHostingEnvironment Host { get; }

        public async Task<IEnumerable<MaterialViewModel>> GetAllMaterials()
        {
            string includedProperty = nameof(Material);
            var dataFromDb =await Category.GetWhereAsync(null, includedProperty);
             IEnumerable<MaterialViewModel> materialViewModels =dataFromDb.Select(x=>new MaterialViewModel() 
             { 
                 CategoryName=x.CategoryName,
                 MAterilas=x.Materials.Select(x=>new Material() { 
                 FileName=x.FileName,
                 FilePath=x.FilePath,
                 
                 
                 }).ToList()
            
             
             }) ;

            return materialViewModels;
        }
        #endregion

        public async Task<ApiResponse<bool>> UploadFile(UploadFileViewModel file)
        {
            #region Declare Return Value
            ApiResponse<bool> response = new ApiResponse<bool>();
            #endregion

            try
            {
                string UniqueFileNane = default;
                if (file.File is not null)
                {
                    string UploaderFolder = Path.Combine(Host.WebRootPath, "Material");
                    UniqueFileNane = Guid.NewGuid().ToString() + "_" + file.File.FileName;
                    string FilePaht = Path.Combine(UploaderFolder, UniqueFileNane);
                    //it uses the path to create it into the desk 
                    using (var stream = new FileStream(FilePaht, FileMode.Create))
                    {
                        await file.File.CopyToAsync(stream);
                    };

                    var samecategory = await Material.GetAnyAsync(x => x.Category.CategoryName.Equals(file.CtegoryName));
                    if (samecategory)
                    {
                        long selectedId = (await Material.GetFirstOrDefaultAsync(x => x.Category.CategoryName.Equals(file.CtegoryName))).Id;
                        Material materialWithSameCategory = new Material
                        {
                            FileName = file.File.FileName,
                            FilePath = UniqueFileNane,
                            CategoryId = selectedId
                        };
                        await Material.InsertAsync(materialWithSameCategory);
  
                    }
                    else
                    {

                        Material material = new Material
                        {
                            FileName = file.File.FileName,
                            FilePath = UniqueFileNane,
                            Category = new Category()
                            {
                                CategoryName = file.CtegoryName
                            }
                        };
                        await Material.InsertAsync(material);
                    }


                }


                bool isSuccess = await UnitOfWork.SaveChangesAsync();
                if (isSuccess)
                {
                    await UnitOfWork.SaveChangesAsync();
                    response.IsValidResponse = true;
                    //to Add MessageResourceReader with its layers
                    response.CommandMessage = "File Added Successfully ";
                }
            }
            catch (Exception ex )
            {

                throw;
            }

           
            return response;
        }


    }
}
