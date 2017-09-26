using GroceriesTool.DAL.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GroceriesTool.DAL.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : class, IDb
    {
        public void Add(T item)
        {
            throw new NotImplementedException();
        }

        public Task<T> Find(int key)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(int key)
        {
            throw new NotImplementedException();
        }

        public void Update(T item)
        {
            throw new NotImplementedException();
        }
    }
}
