using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GroceriesTool.DAL.Context;
using GroceriesTool.Models;
using Microsoft.EntityFrameworkCore;
using GroceriesTool.DAL.Models;
using AutoMapper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GroceriesTool.Controllers
{
    [Route("api/[controller]")]
    public class StoresAPIController : Controller
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public StoresAPIController(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _context.Stores.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            try
            {
                var item = await _context.Stores.FirstOrDefaultAsync(t => t.Id == id);
                return Ok(item);
            }
            catch
            {
                return NotFound();
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Stores item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _context.Stores.Add(item);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] Stores item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var store = _mapper.Map<Stores>(item);

                _context.Stores.Update(store);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                var Stores = _context.Stores.FirstOrDefault(t => t.Id == id);

                _context.Stores.Remove(Stores);
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