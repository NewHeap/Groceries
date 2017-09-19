using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GroceriesTool.DAL.Models
{
    public class Groceries : IDb
    {
        [Key]
        public int Id { get; set; }
        public string Product { get; set; }
        public string Stock { get; set; }
        public string Price { get; set; }
        public string Code { get; set; }
        public string BuyLocation { get; set; }
        public string StoreName { get; set; }
    }
}
