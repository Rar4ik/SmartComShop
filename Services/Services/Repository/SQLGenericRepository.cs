using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces.Repository;
using SmartCom.DAL.Context;

namespace Services.Repository
{
    public class SQLGenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        readonly DbSet<TEntity> _dbSet;
        private DbContext _context;

        public SQLGenericRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        } 
        public void Create(TEntity itemEntity)
        {
            _dbSet.Add(itemEntity);
        }

        public TEntity FindById(Guid id)
        {
            return _dbSet.Find(id);
        }
        public IEnumerable<TEntity> Get()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return _dbSet.AsNoTracking().Where(predicate).ToList();
        }

        public void Remove(TEntity item)
        {
            if (typeof(TEntity).GUID != Guid.Empty)
            {
                _context.Entry(item).State = EntityState.Deleted;
            }
            //_dbSet.Remove(item);
        }

        public void Update(TEntity item)
        {

            _context.Entry(item).State = EntityState.Modified;
            //_dbSet.AddOrUpdate(item);
        }
    }
}

