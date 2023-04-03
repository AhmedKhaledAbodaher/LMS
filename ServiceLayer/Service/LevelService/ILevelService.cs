using cloudscribe.Pagination.Models;
using DomainLayer.Models;
using Microsoft.AspNetCore.Mvc;
using ShredKernal.Generics;
using ShredKernal.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Service.MaterialService
{
    public interface ILevelService
    {

        Task<List<Level>>GetAllLevels();
    }
    
}
