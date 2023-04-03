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
    public class LevelRepository : Repository<Level>, ILevelRepository
    {
        private DbSet<Level> entity;
        #region Constructor  
        public LevelRepository(ApplicationDbContext context) : base(context)
        {
            entity = context.Set<Level>();
        }
        #endregion
    }
}
