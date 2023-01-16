using CafeWebApi.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CafeWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeDishController : ControllerBase
    {
        private readonly ApplicationContext _db;

        public TypeDishController(ApplicationContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<List<TypeDish>>> Get()
        {
            return Ok(await _db.TypesDish.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<TypeDish>>> Get(int id)
        {
            var typeDish = await _db.TypesDish.FindAsync(id);

            if (typeDish == null)
                return BadRequest("Type dish not found");

            return Ok(typeDish);
        }

        [HttpPost]
        public async Task<ActionResult<List<TypeDish>>> AddBreakfast(TypeDish addTypeDish)
        {
            _db.TypesDish.AddAsync(addTypeDish);
            await _db.SaveChangesAsync();

            return Ok(await _db.TypesDish.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<TypeDish>>> UpdateBreakfast(TypeDish request)
        {
            var typeDish = await _db.TypesDish.FindAsync(request.Id);

            if (typeDish == null)
                return BadRequest("Type dish not found");

            typeDish.Name = request.Name;

            await _db.SaveChangesAsync();

            return Ok(await _db.TypesDish.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<TypeDish>>> Delete(int id)
        {
            var typeDish = await _db.TypesDish.FindAsync(id);

            if (typeDish == null)
                return BadRequest("Type dish not found");

            _db.TypesDish.Remove(typeDish);
            await _db.SaveChangesAsync();

            return Ok(await _db.TypesDish.ToListAsync());
        }
    }
}
