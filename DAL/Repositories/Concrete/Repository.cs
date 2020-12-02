using DAL.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Concrete
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected DbContext _context;
        private DbSet<TEntity> _dbset;
        public Repository(DbContext context)
        {
            _context = context;
            _dbset = _context.Set<TEntity>();
        }
        public void Add(TEntity entity)
        {
            _dbset.Add(entity);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbset.ToList();
        }

        public TEntity GetById(int id)
        {
            return _dbset.Find(id);
        }

        public void Remove(int id)
        {
            _dbset.Remove(GetById(id));
        }
    }
}
