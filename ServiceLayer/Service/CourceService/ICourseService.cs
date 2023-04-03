using DomainLayer.Models;
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

    }
}
