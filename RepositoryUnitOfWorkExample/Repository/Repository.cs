using RepositoryUnitOfWorkExample.FileContext;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RepositoryUnitOfWorkExample.Repository
{
    class Repository<T> : IRepository<T> where T : Entity
    {
        private readonly ISet<T> _entities;

        protected Repository(IContext<T> context)
        {
            _entities = context.Set();
        }

        public void Add(T entity)
        {
            _ = _entities.Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            foreach (T entity in entities)
            {
                _ = _entities.Add(entity);
            }
        }

        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return _entities.Where(predicate);
        }

        public IEnumerable<T> GetAll()
        {
            return _entities.ToList();
        }

        public T GetById(long id)
        {
            return _entities.First(t => t.Id == id);
        }

        public void Remove(T Entity)
        {
            _ = _entities.Remove(Entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            foreach(T entity in entities)
            {
                _ = _entities.Remove(entity);
            }
        }
    }
}
