using System.Collections.Generic;

namespace RepositoryLayer.Repository
{
    public interface IUpdateRepository<T> where T : class
    {
        #region Update
        void Update(T entity);
        void BulkUpdate(List<T> entities);

        #endregion
    }
}
