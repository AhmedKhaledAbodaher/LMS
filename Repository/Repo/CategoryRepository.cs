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
    public class CategoryRepository: Repository<Category>, ICategoryRepository
    {
        private DbSet<Category> entity;
        #region Constructor  
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
            entity = context.Set<Category>();
        }
        #endregion
    }
}
