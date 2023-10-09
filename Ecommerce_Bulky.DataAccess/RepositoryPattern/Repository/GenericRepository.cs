using Ecommerce_Bulky.DataAccess.RepositoryPattern.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_Bulky.DataAccess.RepositoryPattern.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();   
        }

        public async Task CreateAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync(bool tracked = true)
        {
            IQueryable<T> query = _dbSet;
            if (!tracked) 
            {
                query = query.AsNoTracking();
            }
            return await query.ToListAsync();
        }
        public IEnumerable<T> GetAll(bool tracked = true)
        {
            IQueryable<T> query = _dbSet;
            if (!tracked)
            {
                query = query.AsNoTracking();
            }
            return query.ToList();
        }

        public async Task<T> GetByIdAsync(Expression<Func<T, bool>>? filter = null, bool tracked = true)
        {
            IQueryable<T> query = _dbSet;
            if (!tracked)
            {
                query = query.AsNoTracking();
            }
            if (filter != null) 
            {
                query = query.Where(filter);
            }
            return await query.FirstOrDefaultAsync();
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }
    }
}
