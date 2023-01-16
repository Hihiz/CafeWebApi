using CafeWebApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CafeWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BreakfastController : ControllerBase
    {

        private readonly ApplicationContext _db;

        public BreakfastController(ApplicationContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<List<Breakfast>>> Get()
        {
            return Ok(await _db.Breakfasts.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Breakfast>>> Get(int id)
        {
            var breakfast = await _db.Breakfasts.FindAsync(id);

            if (breakfast == null)
                return BadRequest("Breakfast not found");

            return Ok(breakfast);
        }

        [HttpPost]
        public async Task<ActionResult<List<Breakfast>>> AddBreakfast(Breakfast addBreakfast)
        {
            _db.Breakfasts.AddAsync(addBreakfast);
            await _db.SaveChangesAsync();

            return Ok(await _db.Breakfasts.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Breakfast>>> UpdateBreakfast(Breakfast request)
        {
            var breakfast = await _db.Breakfasts.FindAsync(request.Id);

            if (breakfast == null)
                return BadRequest("Breakfast not found");

            breakfast.Name = request.Name;
            breakfast.Type = request.Type;
            breakfast.Type = request.Type;
            breakfast.Description = request.Description;

            await _db.SaveChangesAsync();

            return Ok(await _db.Breakfasts.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Breakfast>>> Delete(int id)
        {
            var breakfast = await _db.Breakfasts.FindAsync(id);

            if (breakfast == null)
                return BadRequest("Breakfast not found");

            _db.Breakfasts.Remove(breakfast);
            await _db.SaveChangesAsync();

            return Ok(await _db.Breakfasts.ToListAsync());
        }
    }
}
