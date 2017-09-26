using GroceriesTool.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GroceriesTool.DAL.Repositories
{
    public abstract class Repository<T> : IRepositories<T> where T : class, IDb
    {

    }
}
