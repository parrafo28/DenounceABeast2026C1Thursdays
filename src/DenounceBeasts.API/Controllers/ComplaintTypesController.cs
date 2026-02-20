using DenounceBeasts.API.Data;
using DenounceBeasts.API.Data.Entities;
using DenounceBeasts.API.Models;
using DenounceBeasts.API.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace DenounceBeasts.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComplaintTypesController : ControllerBase
    {

        private readonly ApplicationDataContext _context;

        public ComplaintTypesController(ApplicationDataContext context)
        {
            _context = context;
        }
         
        [HttpGet]
        public ActionResult<IEnumerable<ComplaintTypeDto>> GetAll()
        {
            var complaintTypesFromDb = _context.ComplaintTypes.ToList();

            var response = complaintTypesFromDb.Select(m => new ComplaintTypeDto
            {
                Id = m.Id,
                Name = m.Name, 
            }).ToList();

            return Ok(response);

        }
         
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {

            var complaintType = _context.ComplaintTypes.FirstOrDefault(m => m.Id == id);
            if (complaintType == null)
            {
                return NotFound();
            }
            var response = new ComplaintTypeDto
            {
                Id = complaintType.Id,
                Name = complaintType.Name, 
            };
            return Ok(response);
        }

        [HttpPost]
        public IActionResult Create(ComplaintTypeDto request)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
            {
                return BadRequest("Name of complaintType is required.");
            }
            
            var complaintType = new ComplaintType
            { 
                Name = request.Name, 
            };

            _context.Add(complaintType);
            _context.SaveChanges();

            return CreatedAtAction(
                nameof(GetById),
                new { id = complaintType.Id },
                request
            );
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, ComplaintTypeDto request)
        {
            var existing = _context.ComplaintTypes.FirstOrDefault(m => m.Id == id);
            if (existing == null)
            {
                return NotFound();
            }

            existing.Name = request.Name; 
            _context.Update(existing);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existing = _context.ComplaintTypes.FirstOrDefault(m => m.Id == id);
            if (existing == null)
            {
                return NotFound();
            }
            _context.ComplaintTypes.Remove(existing);
            _context.SaveChanges();
            return NoContent();
        }

    }
}
