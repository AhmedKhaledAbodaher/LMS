using System;
using System.Threading.Tasks;

namespace RepositoryLayer.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> SaveChangesAsync();
        void SaveChangesTransactionAsync();
    }
}
