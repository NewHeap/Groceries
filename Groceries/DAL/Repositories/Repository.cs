using GroceriesTool.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GroceriesTool.DAL.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : class, IDb
    {
        public void Add(T item)
        {
            throw new System.NotImplementedException();
        }

        public Task<T> Find(int key)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAll()
        {
            throw new System.NotImplementedException();
        }
       
        public Task<IEnumerable<T>> SaveChangesAsync()
        {
            throw new System.NotImplementedException();
        }
        public void Remove(int key)
        {
            throw new System.NotImplementedException();
        }

        public void Update(T item)
        {
            throw new System.NotImplementedException();
        }
    }
}
