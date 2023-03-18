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
    public class VideoRepository: Repository<Video>, IVideoRepository
    {
        private DbSet<Video> entity;
        #region Constructor  
        public VideoRepository(ApplicationDbContext context) : base(context)
        {
            entity = context.Set<Video>();
        }
        #endregion
    }
}
