namespace RepositoryLayer.Repository
{
    public interface IRepository<T> : IInsertRepository<T>, IUpdateRepository<T>, IDeleteRepository<T>, IRetreiveRepository<T> where T : class
    {

    }
}
