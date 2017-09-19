using GroceriesTool.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceriesTool.DAL.Context
{
    public class DatabaseContext : DbContext
    {
        public static string ConnectionString { get; set; }

        public DbSet<Groceries> Groceries { get; set; }
        public DbSet<Stores> Stores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }
    }
}
