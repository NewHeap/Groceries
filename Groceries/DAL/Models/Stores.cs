using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GroceriesTool.DAL.Models
{
    public class Stores : IDb
    {
        [Key]
        public int Id { get; set; }
        public string StoreName { get; set; }
        public string StoreLocation { get; set; }
        public string Openinghours { get; set; }
        public string Closinghours { get; set; }
    }
}
