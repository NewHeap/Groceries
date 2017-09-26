using GroceriesTool.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GroceriesTool.DAL.Repositories
{
    public interface IRepositories<T> where T : class, IDb
    {
        void Add(T item);
        Task<IEnumerable<T>> GetAll();
        Task<T> Find(int key);
        void Remove(int key);
        void Update(T item);
    }
}
