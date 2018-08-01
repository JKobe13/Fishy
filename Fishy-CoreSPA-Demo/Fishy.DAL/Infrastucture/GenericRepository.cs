using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Fishy.DAL.Infrastucture
{
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : Entity
    {
        public List<TEntity> _items;

        protected GenericRepository(List<TEntity> itemsCollection)
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

        public IEnumerable<TEntity> Get(IEnumerable<int> ids)
        {
            return _items.Where(x => ids.Any(id => id == x.Id));
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
                _items.Add(entity);
                return entity;
            }
            if (!_items.Any(x => x.Id == entity.Id))
            {
                _items.Add(entity);
                return entity;
            }
            else throw new Exception($"Index conflict on {typeof(TEntity).Name}");
        }

        public TEntity Modify(TEntity entity)
        {
            var entityToEdit = Get(entity.Id);
            if (entityToEdit != null)
            {
                var index = _items.IndexOf(entityToEdit);
                _items[index] = entity;
                return _items[index];
            }
            else throw new Exception($"No entity with Id");
        }
    }
}
