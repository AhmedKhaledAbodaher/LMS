using AutoMapper;
using cloudscribe.Pagination.Models;
using DomainLayer.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Repository.IRepo;
using Repository.Repo;
using RepositoryLayer.UnitOfWork;
using ServiceLayer.Service.BaseService;
using ShredKernal.Generics;
using ShredKernal.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Service.MaterialService
{
    public class LevelService : BaseAppService, ILevelService
    {
        public LevelService(IConfiguration configuration, ICategoryRepository cat, 
            Microsoft.AspNetCore.Hosting.IHostingEnvironment _ost, ILevelRepository level,
               IUnitOfWork unitOfWork, IMapper mapper) : base(
                    unitOfWork, mapper)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            Level = level;
            Host = _ost;

        }
        public IMapper Mapper { get; set; }
        public IUnitOfWork UnitOfWork { get; }
        public ILevelRepository Level { get; }
        
        public Microsoft.AspNetCore.Hosting.IHostingEnvironment Host { get; }

        public Task<List<Level>> GetAllLevels()
        {
            return Level.GetWhereAsync();
        }
    }
}
