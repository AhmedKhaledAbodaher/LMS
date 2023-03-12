namespace RepositoryLayer.Repository
{
    public interface IDeleteRepository<T> where T : class
    {
        #region Delete
        void HardDelete(T entity);
        #endregion
    }
}
