using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service
{
    public interface IBaseService<T> where T : class
    {
        IQueryable<T> GetAll();

        T Get(int id);

        void Add(T entity);

        void Delete(T entity);

        void Update(T entity);

        void SaveChanges();
    }
}
