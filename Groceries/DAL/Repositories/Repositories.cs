using GroceriesTool.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroceriesTool.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace GroceriesTool.DAL.Repositories
{
    public class GroceriesRepository : Repository<Groceries>
    {
        public GroceriesRepository(DatabaseContext context) : base(context)
        {

        }
    }
    public class StoresRepository : Repository<Stores>
    {
        public StoresRepository(DatabaseContext context) : base(context)
        {

        }
    }
}