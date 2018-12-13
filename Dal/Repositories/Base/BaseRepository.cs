using System;
using Dal.EF;
using Domain.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Dal.Repositories.Base
{
    public class BaseRepository<T> : IDisposable where T : EntityBase, new()
    {
        protected readonly DbSet<T> _entitySet;

        private ApplicationDbContext _dbContext;
        protected ApplicationDbContext Context => _dbContext;

        public BaseRepository() : this(new ApplicationDbContext())
        {
        }

        public BaseRepository(ApplicationDbContext dbContext) 
        {
            _dbContext = dbContext;
            _entitySet = _dbContext.Set<T>();
        }


        internal protected int SaveChanges()
        {
            try
            {
                return _dbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex) //TODO
            {
                throw;
            }
            catch (RetryLimitExceededException ex)
            {
                throw;
            }
            catch (DbUpdateException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _dbContext?.Dispose();
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}
