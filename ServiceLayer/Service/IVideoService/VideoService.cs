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
    public class VideoService : BaseAppService, IVieoService
    {
        public VideoService(IGenreRepository genre, IVideoRepository video, IConfiguration configuration, ICategoryRepository cat, Microsoft.AspNetCore.Hosting.IHostingEnvironment _ost, IMaterialRepository material,
               IUnitOfWork unitOfWork, IMapper mapper) : base(
                    unitOfWork, mapper)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            Material = material;
            Host = _ost;
            Category = cat;
            Genre = genre;
            Video = video;

        }
        public IMapper Mapper { get; set; }
        public IUnitOfWork UnitOfWork { get; }
        public IMaterilaService Materila { get; }
        public IMaterialRepository Material { get; }
        public ICategoryRepository Category { get; }
        public IVideoRepository Video { get; }
        public IGenreRepository Genre { get; }
        public Microsoft.AspNetCore.Hosting.IHostingEnvironment Host { get; }

        public async Task<ApiResponse<bool>> UploadFile(UploadVideoViewModel file)
        {

            #region Declare Return Value
            ApiResponse<bool> response = new ApiResponse<bool>();
            #endregion

            try
            {
                if (file is not null)
                {
                    Video video = new Video() {
                        VideoName = file.Name,
                        VideoUrl = file.VideoUrl,
                       Genre=new Genre() { 
                       GenreName=file.GenreName,
                       }
                     
                    
                    };
                   
                }


                bool isSuccess = await UnitOfWork.SaveChangesAsync();
                if (isSuccess)
                {
                    await UnitOfWork.SaveChangesAsync();
                    response.IsValidResponse = true;
                    //to Add MessageResourceReader with its layers
                    response.CommandMessage = "File Added Successfully ";
                }
            }
            catch (Exception ex)
            {

                throw;
            }


            return response;
        }
    }
}
