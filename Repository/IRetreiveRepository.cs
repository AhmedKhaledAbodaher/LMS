using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using static SharedEnums;

namespace Repository
{
    public interface IRetreiveRepository<T> where T : class
    {
        #region Retreive

        #region GetById
        Task<T> GetById<r>(r Id);
        #endregion

        #region GetList
        Task<List<T>> GetWhereAsync(Expression<Func<T, bool>> filter = null, string includeProperties = "");
        Task<List<T>> GetWhereAsync<TKey>(Expression<Func<T, bool>> filter = null, string includeProperties = "", Expression<Func<T, TKey>> sortingExpression = null, SortDirection sortDir = SortDirection.Ascending);
        #endregion

        #region Get Paged
        Task<List<T>> GetPageAsync<TKey>(int PageNumeber, int PageSize, Expression<Func<T, bool>> filter=null,
            Expression<Func<T, TKey>> sortingExpression=null,
            SortDirection sortDir = SortDirection.Ascending,
            string includeProperties = ""); 
        Task<List<T>> GetPageAsyncEx<TKey>(int PageNumeber, int PageSize, Expression<Func<T, bool>> filter = null,
           
            string includeProperties = "");
        #endregion

        #region Get Individuals
        Task<int> GetCountAsync(Expression<Func<T, bool>> filter = null);
        Task<bool> GetAnyAsync(Expression<Func<T, bool>> filter = null, string includeProperties = "");
        Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> filter = null, string includeProperties = "");
        Task<T> GetLastOrDefaultAsync(Expression<Func<T, bool>> filter = null, string includeProperties = "");

        #endregion

        #endregion
    }
}
