using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Dal.EF;
using Domain.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Dal.Repositories.Base
{
    public class BaseRepository<T> : IDisposable, IRepository<T> where T : EntityBase, new()
    {
        private readonly DbSet<T> _entitySet;

        private ApplicationDbContext _dbContext;
        protected ApplicationDbContext Context => _dbContext;

        public BaseRepository() : this(new ApplicationDbContext())
        {
        }

        public BaseRepository(ApplicationDbContext context) 
        {
            _dbContext = context;
            _entitySet = _dbContext.Set<T>();
        }

        public int Add(T entity)
        {
            _entitySet.Add(entity);
            return SaveChanges();
        }

        public int Add(IEnumerable<T> entities)
        {
            _entitySet.AddRange(entities);
            return SaveChanges();
        }

        public int Update(T entity)
        {
            _entitySet.Update(entity);
            return SaveChanges();
        }

        public int Update(IEnumerable<T> entities)
        {
            _entitySet.UpdateRange(entities);
            return SaveChanges();
        }

        public int Delete(int id, byte[] timeStamp)
        {
            _dbContext.Entry(new T() { Id = id, TimeStamp = timeStamp }).State = EntityState.Deleted;
            return SaveChanges();
        }

        public int Delete(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Deleted;
            return SaveChanges();
        }

        public T GetOne(int? id) => _entitySet.Find(id);

        public IQueryable<T> GetSome(Expression<Func<T, bool>> where) => _entitySet.Where(where);

        public IQueryable<T> GetAll() => _entitySet;

        public IQueryable<T> GetAll<TSortField>(Expression<Func<T, TSortField>> orderBy, bool ascending) =>
            ascending ? _entitySet.OrderBy(orderBy) : _entitySet.OrderByDescending(orderBy);


        internal int SaveChanges()
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
