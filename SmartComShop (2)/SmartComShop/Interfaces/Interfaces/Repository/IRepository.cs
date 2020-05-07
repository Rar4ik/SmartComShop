using System;
using System.Collections.Generic;

namespace Interfaces.Repository
{
    public interface IRepository<T>
        where T : class
    {
        IEnumerable<T> GetList();
        T Get(Guid id);
        void Create(T item);
        void Update(T item);
        void Delete(Guid id);
    }
}
