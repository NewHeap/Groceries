using GroceriesTool.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using GroceriesTool.DAL.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GroceriesTool.DAL.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : class, IDb
    {
        private readonly DatabaseContext _context;

        public Repository(DatabaseContext context)
        {
            _context = context;
        }

        public async void Add(T item)
        {
            await _context.Set<T>().AddAsync(item);
            _context.SaveChanges();
        }

        async Task IRepository<T>.AddAsync(T item)
        {
            await _context.Set<T>().AddAsync(item);
            _context.SaveChanges();
        }


        public T Find(int key)
        {
            return _context.Set<T>().FirstOrDefault(t => t.Id == key);
        }

        public T Find(string key)
        {
            return _context.Set<T>().FirstOrDefault(t => t.Id.ToString() == key);
        }

        public async Task<T> FindAsync(string key)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(t => t.Id.ToString() == key);
        }

        public async Task<T> FindAsync(int key)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(t => t.Id == key);
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public async Task<IQueryable<T>> GetAllAsync()
        {
            return _context.Set<T>();
        }

        public void Remove(int key)
        {
            var entity = Find(key);
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public async Task RemoveAsync(int key)
        {
            var entity = await _context.Set<T>().FirstAsync(t => t.Id == key);
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public void Update(T item)
        {
            _context.Set<T>().Update(item);
            _context.SaveChanges();
        }

        public async Task UpdateAsync(T item)
        {
            _context.Set<T>().Update(item);
            await SaveChangesAsync();

        }

        public async Task<bool> AnyAsync(string key)
        {
            var result = await _context.Set<T>().AnyAsync(t => t.Id.ToString().Equals(key));
            return result;
        }

        public bool Any(string key)
        {
            var result = _context.Set<T>().Any(t => t.Id.ToString() == key);
            return result;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }


    }
}
