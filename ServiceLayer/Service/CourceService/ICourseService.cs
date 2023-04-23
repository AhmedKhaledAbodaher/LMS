using DomainLayer.Models;
using ShredKernal.Generics;
using ShredKernal.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Service.CourceService
{
    public interface ICourseService
    {
        Task<List<Course>> GetCourses(Expression<Func<Course,bool>> func);
        Task<List<CourseFiles>> GetCoursesFiles(int courseId);
        Task<ApiResponse<bool>> UploadFile(UploadCourseFileViewModel file);

    }
}
