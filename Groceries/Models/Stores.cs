using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceriesTool.Models
{
    public class Stores
    {
        public int GroceriesID { get; set; }
        public string Product  { get; set; }
        public int Stock { get; set; }
        public int Price { get; set; }
        public int Code { get; set; }
        public String Location { get; set; }
        public int StoreID { get; set; }
        public int StoresID { get; internal set; }
    }
}
