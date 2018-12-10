using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Dal.Repositories.Base
{
    public interface IRepository<T>
    {
        int Add(T entity);
        int Add(IEnumerable<T> entities);
        int Update(T entity);
        int Update(IEnumerable<T> entities);
        int Delete(int id, byte[] timeStamp);
        int Delete(T entity);
        T GetOne(int? id);
        IQueryable<T> GetSome(Expression<Func<T, bool>> where);
        IQueryable<T> GetAll();
        IQueryable<T> GetAll<TSortField>(Expression<Func<T, TSortField>> orderBy, bool ascending);
    }
}
