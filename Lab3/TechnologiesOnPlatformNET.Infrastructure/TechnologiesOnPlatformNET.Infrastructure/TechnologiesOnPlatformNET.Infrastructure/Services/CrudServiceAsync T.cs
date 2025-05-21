using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnologiesOnPlatformNET.Infrastructure;
using TechnologiesOnPlatformNET.Infrastructure.Context;
using TechnologiesOnPlatformNET.Infrastructure.Repositories;

namespace TechnologiesOnPlatformNET.Infrastructure.Services
{
    public class CrudServiceAsync<T> : ICrudServiceAsync<T> where T : class
    {
        private readonly IRepository<T> _repository;
        private readonly TechnologiesDbContext _context;

        public CrudServiceAsync(IRepository<T> repository, TechnologiesDbContext context)
        {
            _repository = repository;
            _context = context;
        }

        public async Task<bool> CreateAsync(T element)
        {
            await _repository.AddAsync(element);
            return true;
        }

        public async Task<T> ReadAsync(Guid id) => await _repository.GetByIdAsync(id);
        public async Task<IEnumerable<T>> ReadAllAsync() => await _repository.GetAllAsync();

        public async Task<IEnumerable<T>> ReadAllAsync(int page, int amount)
        {
            return await _context.Set<T>()
                .Skip((page - 1) * amount)
                .Take(amount)
                .ToListAsync();
        }

        public async Task<bool> UpdateAsync(T element)
        {
            await _repository.Update(element);
            return true;
        }

        public async Task<bool> RemoveAsync(T element)
        {
            await _repository.Delete(element);
            return true;
        }

        public async Task<bool> SaveAsync() => await _context.SaveChangesAsync() > 0;
    }
}