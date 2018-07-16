using System;
using System.Collections.Generic;
using System.Text;

namespace Fishy.DAL.Infrastucture
{
    public interface IGenericRepository<TEntity> 
    {
        TEntity Get(int id);

        IEnumerable<TEntity> Get(IEnumerable<int> ids);

        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> Find(Func<TEntity, bool> predicate);

        TEntity Add(TEntity entity);
    }
}
