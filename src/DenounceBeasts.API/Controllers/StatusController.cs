using DenounceBeasts.API.Data;
using DenounceBeasts.API.Data.Entities;
using DenounceBeasts.API.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace DenounceBeasts.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatusController : BaseController<Status>
    {

        //private readonly ApplicationDataContext _context;

        public StatusController(ApplicationDataContext context): base(context)
        {
            //_context = context;
        }

        [HttpGet]
        [Route ("GetAll")]
        public ActionResult<IEnumerable<StatusDto>> GetAll()
        {
            var statusFromDb = Context.Status.ToList();

            var response = statusFromDb.Select(m => new StatusDto
            {
                Id = m.Id,
                Name = m.Name
            }).ToList();

            return Ok(response);

        }

        //[HttpGet("{id}")]
        //public IActionResult GetById(int id)
        //{

        //    var status = _context.Status.FirstOrDefault(m => m.Id == id);
        //    if (status == null)
        //    {
        //        return NotFound();
        //    }
        //    var response = new StatusDto
        //    {
        //        Id = status.Id,
        //        Name = status.Name
        //    };
        //    return Ok(response);
        //}

        //[HttpPost]
        //public IActionResult Create(StatusDto request)
        //{
        //    if (string.IsNullOrWhiteSpace(request.Name))
        //    {
        //        return BadRequest("Name of status is required.");
        //    }

        //    var status = new Status
        //    {
        //        Name = request.Name, 
        //    };

        //    _context.Add(status);
        //    _context.SaveChanges();

        //    return CreatedAtAction(
        //        nameof(GetById),
        //        new { id = status.Id },
        //        request
        //    );
        //}

        //[HttpPut("{id}")]
        //public IActionResult Update(int id, StatusDto request)
        //{
        //    var existing = _context.Status.FirstOrDefault(m => m.Id == id);
        //    if (existing == null)
        //    {
        //        return NotFound();
        //    }

        //    existing.Name = request.Name; 
        //    _context.Update(existing);
        //    _context.SaveChanges();
        //    return NoContent();
        //}

        //[HttpDelete("{id}")]
        //public IActionResult Delete(int id)
        //{
        //    var existing = _context.Status.FirstOrDefault(m => m.Id == id);
        //    if (existing == null)
        //    {
        //        return NotFound();
        //    }
        //    _context.Status.Remove(existing);
        //    _context.SaveChanges();
        //    return NoContent();
        //}

    }
}
