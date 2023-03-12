using RepositoryLayer.Context;
using System;
using System.Threading.Tasks;

namespace RepositoryLayer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool disposedValue;

        private readonly ApplicationDbContext _applicationDbContext;

        public UnitOfWork(ApplicationDbContext applicationDbContext)
        {
            this._applicationDbContext = applicationDbContext;
        }

        public async Task<bool> SaveChangesAsync()
        {
            try
            {

                var changes = await _applicationDbContext.SaveChangesAsync();
                return changes > default(byte);
            }
            catch (Exception e)
            {

                throw;
            }

        }
        public async void SaveChangesTransactionAsync()
        {
            var transaction = _applicationDbContext.Database.BeginTransaction();

            try
            {

                await transaction.CommitAsync();
                //await _applicationDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                transaction.RollbackToSavepoint("BeforeMoreBlogs");

            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~UnitOfWork()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
