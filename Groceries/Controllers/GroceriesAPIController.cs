using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GroceriesTool.DAL.Context;
using GroceriesTool.Models;
using Microsoft.EntityFrameworkCore;
using GroceriesTool.DAL.Models;
using AutoMapper;

namespace GroceriesTool.Controllers
{
    [Route("api/[controller]")]
    public class GroceriesAPIController : Controller
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public GroceriesAPIController(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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
        public async Task <IActionResult> Post([FromBody] GrocerieViewModel item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var grocerie = _mapper.Map<Groceries>(item);
                _context.Groceries.Add(grocerie);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch
            {
                return BadRequest();
            }

        }
        [HttpPut("{id}")]
        public async Task <IActionResult> Put(long id, [FromBody] GrocerieViewModel item)
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
                //var grocerie = _mapper.Map<Groceries>(item);

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
                var error = $"Didn't find Id {id}";
                return NotFound(error);
            }
        }
    }
}