using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using Repository.IRepo;
using RepositoryLayer.Repository.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repo
{
    internal class CoursesFileRepository : Repository<CourseFiles>, ICoursesFileRepository
    {
        private DbSet<CourseFiles> entity;
        #region Constructor  
        public CoursesFileRepository(ApplicationDbContext context) : base(context)
        {
            entity = context.Set<CourseFiles>();
        }
        #endregion


    }
}