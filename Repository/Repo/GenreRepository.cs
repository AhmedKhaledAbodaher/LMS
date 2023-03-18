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
    public class GenreRepository: Repository<Genre>, IGenreRepository
    {
        private DbSet<Genre> entity;
        #region Constructor  
        public GenreRepository(ApplicationDbContext context) : base(context)
        {
            entity = context.Set<Genre>();
        }
        #endregion
    }
}
