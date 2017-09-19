using GroceriesTool.DAL.Context;
using GroceriesTool.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceriesTool.DAL.repository
{
    public class GroceriesRepository : IRepository<Groceries>
    {
        private readonly DatabaseContext _context;

        public GroceriesRepository(DatabaseContext context)
        {
            _context = context;
        }
        public async void Add(Groceries item)
        {
            await _context.Groceries.AddAsync(item);
            _context.SaveChanges();
        }

        public async Task<Groceries> Find(int key)
        {
            return await _context.Groceries.FirstOrDefaultAsync(t => t.Id == key);
        }   

        public async Task<IEnumerable<Groceries>> GetAll()
        {
            return await _context.Groceries.ToListAsync();
        }

        public async void Remove(int key)
        {
            var entity = await _context.Groceries.FirstAsync(t => t.Id == key);
            _context.Groceries.Remove(entity);
            _context.SaveChanges();
        }
        public void Update(Groceries item)
        {
            _context.Groceries.Update(item);
            _context.SaveChanges();
        }
    }
}
//void add(todoitem item);
//ienumerable<todoitem> getall();
//todoitem find(long key);
//void remove(long key);
//void update(todoitem item)