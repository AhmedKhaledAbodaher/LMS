using AutoMapper;
using DomainLayer.Models;
using Microsoft.Extensions.Configuration;
using Repository.IRepo;
using RepositoryLayer.UnitOfWork;
using ServiceLayer.Service.BaseService;
using ServiceLayer.Service.MaterialService;
using System;
using System.Collections.Generic;
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
               IUnitOfWork unitOfWork, IMapper mapper) : base(
                    unitOfWork, mapper)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            Course = level;
            Host = _ost;

        }
        public IMapper Mapper { get; set; }
        public IUnitOfWork UnitOfWork { get; }
        public ICourseRepository Course { get; }

        public Microsoft.AspNetCore.Hosting.IHostingEnvironment Host { get; }

        public async Task<List<Course>> GetCourses(Expression<Func<Course, bool>> func)
        {
            return await Course.GetWhereAsync(func);
        }
    }
}
