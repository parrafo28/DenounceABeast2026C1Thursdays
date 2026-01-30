using DenounceBeasts.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DenounceBeasts.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MunicipaltiesController: ControllerBase
    {
        private static readonly List<Municipality> _municipalities = new List<Municipality>
        {
            new Municipality { Id = 1, Name = "Santo Domingo", PostalCode = "10101", IsActive = true },
            new Municipality { Id = 2, Name = "Santiago de los Caballeros", PostalCode = "51000", IsActive = true },
            new Municipality { Id = 3, Name = "Puerto Plata", PostalCode = "57000", IsActive = true }
        };


        //[HttpGet]
        //public IActionResult Get()
        //{
        //    var municipalities = new List<Municipality>()
        //    {
        //        new Municipality { Id = 1, Name = "Springfield", PostalCode = "12345" },
        //        new Municipality { Id = 2, Name = "Shelbyville", PostalCode = "67890" }
        //    };
        //    return Ok(municipalities);
        //}

        //[HttpGet("GetMunicipalities")]
        // public IActionResult Getx()
        // {
        //     var municipalities = new List<Municipality>()
        //     {
        //         new Municipality { Id = 1, Name = "Springfield", PostalCode = "12345" },
        //         new Municipality { Id = 2, Name = "Shelbyville", PostalCode = "67890" }
        //     };
        //     return Ok(municipalities);
        // }

        // [HttpGet("/api/GetMunicipalities")] 
        // public IActionResult Getxx()
        // {
        //     var municipalities = new List<Municipality>()
        //     {
        //         new Municipality { Id = 1, Name = "Springfield", PostalCode = "12345" },
        //         new Municipality { Id = 2, Name = "Shelbyville", PostalCode = "67890" }
        //     };
        //     return Ok(municipalities);
        // }

        [HttpGet] // GET: api/municipalities
        public ActionResult<IEnumerable<Municipality>> GetAll()
        {
            // Retornamos 200 OK con la lista completa.

            var response = _municipalities.Select(m => new MunicipalityDto
            {
                Id = m.Id,
                Name = m.Name,
                PostalCode = m.PostalCode,
                IsActive = m.IsActive
            }).ToList();

            //var response2 = new List<MunicipalityDto>();

            //foreach (var item in _municipalities)
            //{
            //    response2.Add(new MunicipalityDto { Id = item.Id, IsActive = item.IsActive, Name = item.Name, PostalCode = item.PostalCode });
            //}

            //return Ok(_municipalities);
            return Ok(response);

        }

        [HttpGet("{id}")] // GET: api/municipalities/5
        public IActionResult GetById(int id)
        {
            var municipality = _municipalities.FirstOrDefault(m => m.Id == id);
            if (municipality == null)
            {
                // Retornar 404 si no se encontró
                return NotFound();
            }
            var response = new MunicipalityDto
            {
                Id = municipality.Id,
                Name = municipality.Name,
                PostalCode = municipality.PostalCode,
                IsActive = municipality.IsActive
            };
            return Ok(response);
        }
        [HttpPost] // POST: api/municipalities
        public IActionResult Create(MunicipalityDto request)
        {
            // Validación manual adicional: nombre no vacío (alternativa a [Required]).
            if (string.IsNullOrWhiteSpace(request.Name))
            {
                return BadRequest("Name of municipality is required.");
            }
            int newId = _municipalities.Any() ? _municipalities.Max(m => m.Id) + 1 : 1;
            //request.Id = newId;
            //          request.IsActive = true;

            var municipality = new Municipality
            {
                Id = newId,
                Name = request.Name,
                PostalCode = request.PostalCode,
                IsActive = true
            };

            _municipalities.Add(municipality);
            //_municipalities.Add(request);
            // Devolver respuesta 201 Created con el recurso creado
            return CreatedAtAction(
                nameof(GetById),              // Nombre de la acción para generar el link de detalle
                new { id = municipality.Id }, // Valores de ruta (el id del nuevo recurso)
                request                  // El objeto creado (en el cuerpo de la respuesta)
            );
           // return Ok(new { Id = municipality.Id });
        }

        [HttpPut("{id}")] // PUT: api/municipalities/5
        public IActionResult Update(int id, MunicipalityDto request)
        {
            var existing = _municipalities.FirstOrDefault(m => m.Id == id);
            if (existing == null)
            {
                return NotFound();
            }
            // Opcional: validar que municipality.Id == id si quisiéramos forzar consistencia.
            // Actualizar propiedades (excepto el Id)
            existing.Name = request.Name;
            existing.PostalCode = request.PostalCode;
            existing.IsActive = request.IsActive;
            // Retornar 204 NoContent indicando que se realizó la operación sin devolver cuerpo.
            return NoContent();
        }

        [HttpDelete("{id}")] // DELETE: api/municipalities/5
        public IActionResult Delete(int id)
        {
            var existing = _municipalities.FirstOrDefault(m => m.Id == id);
            if (existing == null)
            {
                return NotFound();
            }
            _municipalities.Remove(existing);
            // Retornamos 204 NoContent para indicar que se eliminó correctamente (sin contenido).
            return NoContent();
        }



    }
}
