
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public  class BaseService<T> : IBaseService<T> where T : BaseEntity
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;
        public BaseService(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public  T Get(int id)
        {
            return _dbSet.Find(id) ;
        }

        public  IQueryable<T> GetAll()
        {
            return _dbSet.AsNoTracking();
        }

        public  void Add(T entity)
        {
             _dbSet.Add(entity);
          
        }
        public  void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }
        public  void Delete(int id)
        {
            var entity = _dbSet.Find(id);
            _dbSet.Remove(entity);
        }
        public   void  Update(T entity)
        {
            var existing =  _dbSet.Find(entity.Id);
            if (existing != null)
            {
                _context.Entry(existing).CurrentValues.SetValues(entity);
                _context.Entry(existing).Property("CreatedBy").IsModified = false;
                _context.Entry(existing).Property("CreatedDate").IsModified = false;
            }
        }
        public  void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
