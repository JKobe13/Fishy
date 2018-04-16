using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Fishy.DAL.Infrastucture
{
    public abstract class GenericRepository<TEntity> where TEntity : Entity
    {
        protected IEnumerable<TEntity> _items;

        protected GenericRepository(IEnumerable<TEntity> itemsCollection)
        {
            _items = itemsCollection;
        }

        protected GenericRepository()
        {
            _items = new List<TEntity>();
        }

        public TEntity Get(int id)
        {
            return _items.SingleOrDefault(entity => entity.Id == id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _items;
        }

        public IEnumerable<TEntity> Find(Func<TEntity, bool> predicate)
        {
            return _items.Where(predicate);
        }

        public TEntity Add(TEntity entity)
        {
            if (entity.Id == 0)
            {
                var maxID = !_items.Any() ? 0 : _items.Max(x => x.Id);
                entity.Id = maxID + 1;
            }

            _items.Append(entity);

            return entity;
        }
    }
}
