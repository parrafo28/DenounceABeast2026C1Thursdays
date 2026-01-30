using DenounceBeasts.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DenounceBeasts.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SectorsController: ControllerBase
    {
        private static readonly List<Sector> _sectors = new List<Sector>
        {
            new Sector { Id = 1, Name = "Santo Domingo", PostalCode = "10101", IsActive = true },
            new Sector { Id = 2, Name = "Santiago de los Caballeros", PostalCode = "51000", IsActive = true },
            new Sector { Id = 3, Name = "Puerto Plata", PostalCode = "57000", IsActive = true }
        };
         
        [HttpGet] 
        public ActionResult<IEnumerable<Sector>> GetAll()
        {
            return Ok(_sectors);
        }

        [HttpGet("{id}")] 
        public ActionResult<Sector> GetById(int id)
        {
            var sector = _sectors.FirstOrDefault(m => m.Id == id);
            if (sector == null)
            {
                return NotFound();
            }
            return Ok(sector);
        }

        [HttpPost]
        public ActionResult<Sector> Create(Sector sector)
        {
            if (string.IsNullOrWhiteSpace(sector.Name))
            {
                return BadRequest("Name of sector is required.");
            }
            int newId = _sectors.Any() ? _sectors.Max(m => m.Id) + 1 : 1;
            sector.Id = newId;
                      sector.IsActive = true;
           
            _sectors.Add(sector);
            return CreatedAtAction(
                nameof(GetById),             
                new { id = sector.Id },                   sector                 
            );
        }

        [HttpPut("{id}")] 
        public IActionResult Update(int id, Sector sector)
        {
            var existing = _sectors.FirstOrDefault(m => m.Id == id);
            if (existing == null)
            {
                return NotFound();
            }
            existing.Name = sector.Name;
            existing.PostalCode = sector.PostalCode;
            existing.IsActive = sector.IsActive;
           
            return NoContent();
        }

        [HttpDelete("{id}")] 
        public IActionResult Delete(int id)
        {
            var existing = _sectors.FirstOrDefault(m => m.Id == id);
            if (existing == null)
            {
                return NotFound();
            }
            _sectors.Remove(existing);
            return NoContent();
        }



    }
}
