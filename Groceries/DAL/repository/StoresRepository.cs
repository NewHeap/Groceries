using GroceriesTool.DAL.Context;
using GroceriesTool.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceriesTool.DAL.repository
{
    public class StoresRepository : IRepository<Stores>
    {
        private readonly DatabaseContext _context;
        //public Index(DatabaseContext context)
        //{
        //    _context = context;
        //}
        public StoresRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async void Add(Stores item)
        {
            await _context.Stores.AddAsync(item);
            _context.SaveChanges();
        }

        public async Task<Stores> Find(int key)
        {
            return await _context.Stores.FirstOrDefaultAsync(t => t.Id == key);
        }

        public async Task<IEnumerable<Stores>> GetAll()
        {
            return await _context.Stores.ToListAsync();
        }

        public async void Remove(int key)
        {
            var entity = await _context.Stores.FirstAsync(t => t.Id == key);
            _context.Stores.Remove(entity);
            _context.SaveChanges();
        }
        public void Update(Stores item)
        {
            _context.Stores.Update(item);
            _context.SaveChanges();
        }
    }
}
