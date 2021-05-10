using System;
using System.Collections.Generic;

namespace RepositoryUnitOfWorkExample
{
    interface IRepository<T> where T : Entity
    {
        T GetById(long id);

        IEnumerable<T> GetAll();

        IEnumerable<T> Find(Func<T, bool> predicate);

        void Add(T entity);

        void AddRange(IEnumerable<T> entities);

        void Remove(T Entity);

        void RemoveRange(IEnumerable<T> entities);
    }
}
