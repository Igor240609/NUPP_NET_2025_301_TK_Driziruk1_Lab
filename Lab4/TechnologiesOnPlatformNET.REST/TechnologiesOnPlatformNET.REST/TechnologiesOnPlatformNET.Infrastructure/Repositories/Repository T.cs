using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnologiesOnPlatformNET.Infrastructure;
using TechnologiesOnPlatformNET.Infrastructure.Context;

namespace TechnologiesOnPlatformNET.Infrastructure.Repositories 
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly TechnologiesDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(TechnologiesDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<T> GetByIdAsync(Guid id) => await _dbSet.FindAsync(id);
        public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();
        public async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);
        public Task Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return Task.CompletedTask;
        }
        public Task Delete(T entity)
        {
            _dbSet.Remove(entity);
            return Task.CompletedTask;
        }
    }
}