using AutoMapper;
using DomainLayer.Models;
using Microsoft.Extensions.Configuration;
using Repository.IRepo;
using RepositoryLayer.UnitOfWork;
using ServiceLayer.Service.BaseService;
using ServiceLayer.Service.MaterialService;
using ShredKernal.Generics;
using ShredKernal.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Service.CourceService
{
    public class CourseService : BaseAppService, ICourseService
    {

        public CourseService(IConfiguration configuration, ICategoryRepository cat,
            Microsoft.AspNetCore.Hosting.IHostingEnvironment _ost, ICourseRepository level,
               IUnitOfWork unitOfWork, IMapper mapper, ICoursesFileRepository courseFile) : base(
                    unitOfWork, mapper)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            Course = level;
            Host = _ost;
            CourseFile = courseFile;    
        }
        public IMapper Mapper { get; set; }
        public IUnitOfWork UnitOfWork { get; }
        public ICourseRepository Course { get; }
        public ICoursesFileRepository CourseFile { get; }

        public Microsoft.AspNetCore.Hosting.IHostingEnvironment Host { get; }

        public async Task<List<Course>> GetCourses(Expression<Func<Course, bool>> func)
        {
            return await Course.GetWhereAsync(func);
        }  
        public async Task<List<CourseFiles>> GetCoursesFiles(int courseId)
        {
            return await CourseFile.GetWhereAsync(x=>x.CourseId==courseId);
            
        }

        public async Task<ApiResponse<bool>> UploadFile(UploadCourseFileViewModel file)
        {
            #region Declare Return Value
            ApiResponse<bool> response = new ApiResponse<bool>();
            #endregion
            try
            {
                string UniqueFileNane = default;
                if (file.File is not null)
                {
                    string UploaderFolder = Path.Combine(Host.WebRootPath, "CourseFile");
                    UniqueFileNane = Guid.NewGuid().ToString() + "_" + file.File.FileName;
                    string FilePaht = Path.Combine(UploaderFolder, UniqueFileNane);
                    using (var stream = new FileStream(FilePaht, FileMode.Create))
                    {
                        await file.File.CopyToAsync(stream);
                    };
                    var samecategory = await Course.GetAnyAsync(x => x.CourseName.Equals(file.CtegoryName));
                    if (samecategory)
                    {
                        long selectedId = (await Course.GetFirstOrDefaultAsync(x => x.CourseName.Equals(file.CtegoryName))).Id;
                        CourseFiles materialWithSameCategory = new CourseFiles
                        {
                            FileName = file.File.FileName,
                            FilePath = UniqueFileNane,
                            CourseId = (int)selectedId
                        };
                        await CourseFile.InsertAsync(materialWithSameCategory);

                    }
                    else
                    {
                        CourseFiles material = new CourseFiles
                        {
                            FileName = file.File.FileName,
                            FilePath = UniqueFileNane,
                            Course = new Course()
                            {
                                CourseName = file.CtegoryName,
                                LevelId=file.LevelId
                            }
                        };
                        await CourseFile.InsertAsync(material);
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
            catch (Exception)
            {

                throw;
            }

            return response;
        }
    }
}
