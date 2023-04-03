using AutoMapper;
using cloudscribe.Pagination.Models;
using DomainLayer.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
        public ILevelService Materila { get; }
        public IMaterialRepository Material { get; }
        public ICategoryRepository Category { get; }
        public IVideoRepository Video { get; }
        public IGenreRepository Genre { get; }
        public Microsoft.AspNetCore.Hosting.IHostingEnvironment Host { get; }

        public async Task Delete(int id)
        {
            var toBeDeleted = await Video.GetFirstOrDefaultAsync(x => x.Id == id);

            Video.HardDelete(toBeDeleted);
            var res = await UnitOfWork.SaveChangesAsync();
            await Console.Out.WriteLineAsync("any");
        }

        public async Task<List<VideoViewModel>> GetVideos()
        {
            List<VideoViewModel> videoViewModels = new List<VideoViewModel>();
            try
            {
                VideoViewModel vm = new VideoViewModel();
                var dataFromDb = await Genre.GetWhereAsync( null, "Vidoes");
                //  dataFromDb.SelectMany(x => x.Vidoes.Select(x => !x.IsDeleted));
                videoViewModels = dataFromDb.Select(x => new VideoViewModel()
                {
                    GenreId=x.Id,
                   GenreName = x.GenreName,
                    Videos = x.Vidoes.Select(x => new Video()
                    {
                        VideoName = x.VideoName,
                        
                        Id = x.Id,
                        VideoUrl=x.VideoUrl

                    }).OrderBy(x => x.Id).Take(2).ToList()


                }

                ).ToList();

                // result = new PagedResult<MaterialViewModel>
                //{
                //    Data = materialViewModels.ToList(),
                //    TotalItems = materialViewModels.SelectMany(x=>x.MAterilas).Select(x=>x).Count(),
                //    PageNumber=pageNumber,
                //    PageSize=pageSize
                //};



            }
            catch (Exception ex)
            {
                throw;
            }


            return videoViewModels.ToList();
        }

        public async Task<VideoViewModel> GetVideoWithGenre(int genreId)
        {

            var dataFromDb = await Genre.GetFirstOrDefaultAsync(x => x.Id == genreId, "Vidoes");
            VideoViewModel materialVm = new VideoViewModel()
            {
                GenreName = dataFromDb.GenreName,
                Videos = dataFromDb.Vidoes,


            };
            return materialVm;
        }

        public async Task<ApiResponse<bool>> UploadFile(UploadVideoViewModel file)
        {

            #region Declare Return Value
            ApiResponse<bool> response = new ApiResponse<bool>();
            #endregion

            try
            {
                if (file is not null)
                {
                    var samecategory = await Video.GetAnyAsync(x => x.Genre.GenreName.Equals(file.GenreName));

                    if (samecategory)
                    {
                        long selectedId = (await Genre.GetFirstOrDefaultAsync(x => x.GenreName.Equals(file.GenreName))).Id;
                        Video sameVideo = new Video
                        {
                            VideoName = file.Name,
                            VideoUrl = file.VideoUrl,
                            VideoDescription=file.VideoDescription,
                            GenreId = (int)selectedId
                        };
                        await Video.InsertAsync(sameVideo);

                    }
                    else
                    {
                        Video video = new Video()
                        {
                            VideoName = file.Name,
                            VideoUrl = file.VideoUrl,
                            VideoDescription = file.VideoDescription,

                            Genre = new Genre()
                            {
                                GenreName = file.GenreName,
                            }
                        };
                        await Video.InsertAsync(video);
                    }
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
