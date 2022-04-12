using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using web_API.Models;

namespace web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        CitiesContext db;
        public CitiesController(CitiesContext context)
        {
            this.db = context;
        }
        [HttpGet()]
        public  List<City> GetAll()
        {
            return  db.cities.Include(x=>x.coords).ToList();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<City>> Get(int id)
        {
            City city = await db.cities.Include(x=>x.coords).FirstOrDefaultAsync(x => x.Id == id);
            if (city == null)
                return NotFound();
            return new ObjectResult(city);
        }
    }
}
