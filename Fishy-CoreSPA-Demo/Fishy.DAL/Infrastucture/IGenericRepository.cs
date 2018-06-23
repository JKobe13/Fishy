using System;
using System.Collections.Generic;
using System.Text;

namespace Fishy.DAL.Infrastucture
{
    public interface IGenericRepository<TEntity> 
    {
        TEntity Get(int id);

        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> Find(Func<TEntity, bool> predicate);

        TEntity Add(TEntity entity);
    }
}
