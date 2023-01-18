using Microsoft.EntityFrameworkCore;
using Simple_Ecommers_App.Domain.Entities;
using Simple_Ecommers_App.Domain.Repositories;
using Simple_Ecommers_App.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Simple_Ecommers_App.Infrastructure.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : EntityBase
    {
        private readonly SimpleEcommersAppDbContext _context;

        public BaseRepository(SimpleEcommersAppDbContext context)
        {
            _context = context;
        }

        public async Task Add(T entity)
        {
            _context.Add(entity);
            await Task.CompletedTask;
        }

        public async Task Delete(T entity)
        {
            _context.Remove(entity);
            await Task.CompletedTask;
        }

        public async Task<List<T>> Find(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(Guid id)
        {
            return await _context.FindAsync<T>(id);
        }

        public async Task Update(T entity)
        {
            _context.Update(entity);
            await Task.CompletedTask;
        }
    }
}
