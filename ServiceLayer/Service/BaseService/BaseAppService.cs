using AutoMapper;

using RepositoryLayer.UnitOfWork;


namespace ServiceLayer.Service.BaseService
{
    public class BaseAppService
    {
        #region Props
        public IUnitOfWork UnitOfWork { get; }
        public IMapper Mapper { get; }

        #endregion

        #region Ctor

        public BaseAppService(IUnitOfWork unitOfWork, IMapper mapper)
        {

            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }

        #endregion

        #region Method





        #endregion
    }

}
