using CitiesManager.WebApi.DatabaseContext;
using CitiesManager.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CitiesManager.WebApi.Controllers
{
    public class CitiesController : CustomControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Cities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<City>>> GetCities()
        {
            if (_context.Cities == null)
            {
                return NotFound();
            }
            var cities = await _context.Cities.OrderBy(c => c.CityName).ToListAsync();
            return Ok(cities);
        }

        // GET: api/Cities/5
        [HttpGet("{cityID}")]
        public async Task<ActionResult<City>> GetCity(Guid cityID)
        {
            if (_context.Cities == null)
            {
                return NotFound();
            }
            var city = await _context.Cities.FirstOrDefaultAsync(c => c.CityID == cityID);

            if (city == null)
            {
                return Problem(detail: "Invalid CityID", statusCode: 400, title: "City Search");
                //return NotFound();
            }

            return city;
        }

        // PUT: api/Cities/5
        [HttpPut("{cityID}")]
        public async Task<IActionResult> PutCity(Guid cityID, [Bind(nameof(City.CityID), nameof(City.CityName))] City city)
        {
            if (cityID != city.CityID)
            {
                return BadRequest();
            }

            var existingCity = await _context.Cities.FindAsync(cityID);
            if (existingCity == null)
            {
                return NotFound();
            }
            existingCity.CityName = city.CityName;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CityExists(cityID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Cities
        [HttpPost]
        public async Task<ActionResult<City>> PostCity([Bind(nameof(City.CityID), nameof(City.CityName))] City city)
        {
            if (_context.Cities == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Cities'  is null.");
            }
            _context.Cities.Add(city);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCity", new { cityID = city.CityID }, city);
        }

        // DELETE: api/Cities/5
        [HttpDelete("{cityID}")]
        public async Task<IActionResult> DeleteCity(Guid cityID)
        {
            if (_context.Cities == null)
            {
                return NotFound();
            }
            var city = await _context.Cities.FindAsync(cityID);
            if (city == null)
            {
                return NotFound();
            }

            _context.Cities.Remove(city);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CityExists(Guid cityID)
        {
            return (_context.Cities?.Any(e => e.CityID == cityID)).GetValueOrDefault();
        }
    }
}
