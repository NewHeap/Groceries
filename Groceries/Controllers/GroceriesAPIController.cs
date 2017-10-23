using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GroceriesTool.DAL.Repositories;
using GroceriesTool.DAL.Models;
using GroceriesTool.DAL.Context;
using GroceriesTool.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cors;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GroceriesTool.Controllers
{
    [Route("api/[controller]")]
    public class GroceriesAPIController : Controller
    {
        private readonly DatabaseContext _context;

        public GroceriesAPIController(DatabaseContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task <IActionResult> Get()
        {
            return Ok(await _context.Groceries.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task <IActionResult> Get(long id)
        {
            try
            {
            var item = await _context.Groceries.FirstOrDefaultAsync(t => t.Id == id);
            return Ok(item);
            }
            catch
            {
                return NotFound();
            }
        }
        [HttpPost]
        public async Task <IActionResult> Post([FromBody] Groceries item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _context.Groceries.Add(item);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch
            {
                return BadRequest();
            }

        }
        [HttpPut("{id}")]
        public async Task <IActionResult> Put(long id, [FromBody] Groceries item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var grocerie = _context.Groceries.FirstOrDefault(t => t.Id == id);

                grocerie.Product = item.Product;
                grocerie.Stock = item.Stock;
                grocerie.Price = item.Price;
                grocerie.Code = item.Code;
                grocerie.BuyLocation = item.BuyLocation;
                grocerie.StoreName = item.StoreName;

                _context.Groceries.Update(grocerie);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpDelete("{id}")]
        public async Task <IActionResult> Delete(long id)
        {
            try
            {
                var groceries = _context.Groceries.FirstOrDefault(t => t.Id == id);

                _context.Groceries.Remove(groceries);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch
            {
                return NotFound();
            }
        }
    }
}