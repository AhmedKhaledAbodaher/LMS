using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository
{
    public interface IInsertRepository<T> where T : class
    {
        #region Insert
        T Insert(T entity);
        Task<T> InsertAsync(T entity);
        void BulkInsert(List<T> entities);
        #endregion
    }
}
