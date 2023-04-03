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
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        private DbSet<Course> entity;
        #region Constructor  
        public CourseRepository(ApplicationDbContext context) : base(context)
        {
            entity = context.Set<Course>();
        }
        #endregion
    }
}
