using Microsoft.EntityFrameworkCore;
using Murad.AdvertisementApp.Common.Enums;
using Murad.AdvertisementApp.DataAccsess.Context;
using Murad.AdvertisementApp.DataAccsess.Interfaces;
using Murad.AdvertisementApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Murad.AdvertisementApp.DataAccsess.Repositories
{
    public class Repository<T> :IRepository<T> where T : BaseEntity
    {
        private readonly AdvertisementContext _context;

        public Repository(AdvertisementContext context)
        {
            _context = context;
        }

        public async Task<List<T>> GetAllAsync()
        {
          return  await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter)
        {
            return await _context.Set<T>().AsNoTracking().Where(filter).ToListAsync();
        }

        public async Task<List<T>> GetAllAsync<TKey>(Expression<Func<T, TKey>> selector, OrderByType orderByType = OrderByType.DESC)
        {
            return orderByType == OrderByType.ASC ? await _context.Set<T>().AsNoTracking().OrderBy(selector).ToListAsync() : await _context.Set<T>().AsNoTracking().OrderByDescending(selector).ToListAsync();
        }

        public async Task<List<T>> GetAllAsync<TKey>(Expression<Func<T, bool>> filter, Expression<Func<T, TKey>> selector, OrderByType orderByType = OrderByType.DESC)
        {
          return orderByType == OrderByType.ASC ? await _context.Set<T>().Where(filter).AsNoTracking().OrderBy(selector).ToListAsync() : await _context.Set<T>().Where(filter).AsNoTracking().OrderByDescending(selector).ToListAsync();
        }


        public async Task<T> Find(object id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> GetByFilter(Expression<Func<T, bool>> expression, bool asNoTracking = false)
        {
            return !asNoTracking ? await _context.Set<T>().FirstOrDefaultAsync(expression) :
                await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(expression);
        }
        public IQueryable<T> GetQuery()
        {
          return  _context.Set<T>().AsQueryable();
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
        public async Task Create(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public void Update(T entity , T unchanged)
        {
            _context.Entry(unchanged).CurrentValues.SetValues(entity);
        }

        }
}
