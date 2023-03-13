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
    public class MaterialRepository:  Repository<Material>, IMaterialRepository
    {
        private DbSet<Material> entity;
    #region Constructor  
    public MaterialRepository(ApplicationDbContext context) : base(context)
    {
        entity = context.Set<Material>();
    }
    #endregion

}
}
