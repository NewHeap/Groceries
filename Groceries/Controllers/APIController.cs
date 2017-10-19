using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Groceries.Controllers
{
    [Produces("application/json")]
    [Route("api/API")]
    public class APIController : Controller
    {
        //private readonly _context;

        //public APIController(DbContext context)
        //{
        //    _context = context;

        //    if (_context.TodoItems.Count() == 0)
        //    {
        //        _context.TodoItems.Add(new TodoItem { Name = "Item1" });
        //        _context.SaveChanges();
        //    }
        //}
    }
}