using AutoMapper;
using DenounceBeasts.API.Data;
using DenounceBeasts.API.Models;
using DenounceBeasts.API.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DenounceBeasts.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MunicipaltiesController : ControllerBase
    {

        private readonly ApplicationDataContext _context;
        private readonly IMapper _mapper;

        public MunicipaltiesController(ApplicationDataContext context, IMapper mapper)
        {
            _context = context;
            this._mapper = mapper;
        }
         
        [HttpGet]
        public ActionResult<ApiResponse<List<MunicipalityDto>>> GetAll()
        {
            var municipalitiesFromDb = _context.Municipalities.ToList();

            //var response = municipalitiesFromDb.Select(m => new MunicipalityDto
            //{
            //    Id = m.Id,
            //    Name = m.Name,
            //    PostalCode = m.PostalCode,
            //    IsActive = m.IsActive
            //}).ToList();
            var response = _mapper.Map<List<MunicipalityDto>>(municipalitiesFromDb);

            //return Ok(response);
            return ApiResponse<List<MunicipalityDto>>.SuccessResponse(response);

        }

        [HttpGet("with-sectors")]
        public ActionResult<ApiResponse<List<MunicipalityListDto>>> GetAllWithSectors()
        {
            var municipalitiesFromDb = _context
                .Municipalities.Include(p=>p.Sectors)
                .ToList();

            //var response = municipalitiesFromDb.Select(m => new MunicipalityListDto
            //{
            //    Id = m.Id,
            //    Name = m.Name,
            //    PostalCode = m.PostalCode,
            //    Sectors = _context.Sectors
            //        .Where(s => s.MunicipalityId == m.Id)
            //        .Select(s => new SectorDto
            //        {
            //            Id = s.Id,
            //            Name = s.Name,
            //            IsActive = s.IsActive
            //        }).ToList(),
            //    IsActive = m.IsActive
            //}).ToList();

            var response = _mapper.Map<List<MunicipalityListDto>>(municipalitiesFromDb);
            //return Ok(response);
            return ApiResponse<List<MunicipalityListDto>>.SuccessResponse(response);

        }

        [HttpGet("{id}")]
        public ApiResponse<MunicipalityDto> GetById(int id)
        {

            var municipality = _context.Municipalities.FirstOrDefault(m => m.Id == id);
            if (municipality == null)
            {
                return ApiResponse<MunicipalityDto>.FailResponse("Municipality not found.");
                //return NotFound();
            }
            //var response = new MunicipalityDto
            //{
            //    Id = municipality.Id,
            //    Name = municipality.Name,
            //    PostalCode = municipality.PostalCode,
            //    IsActive = municipality.IsActive
            //};
            var response = _mapper.Map<MunicipalityDto>(municipality);
            //return Ok(response);
            return ApiResponse<MunicipalityDto>.SuccessResponse(response);
        }

        [HttpPost]
        public IActionResult Create(MunicipalityDto request)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
            {
                return BadRequest("Name of municipality is required.");
            }
            
            //var municipality = new Municipality
            //{ 
            //    Name = request.Name,
            //    PostalCode = request.PostalCode,
            //    IsActive = true
            //};
            var municipality = _mapper.Map<Municipality>(request);

            _context.Add(municipality);
            _context.SaveChanges();

            return CreatedAtAction(
                nameof(GetById),
                new { id = municipality.Id },
                request
            );
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, MunicipalityDto request)
        {
            var existing = _context.Municipalities.FirstOrDefault(m => m.Id == id);
            if (existing == null)
            {
                return NotFound();
            }

            existing.Name = request.Name;
            existing.PostalCode = request.PostalCode;
            existing.IsActive = request.IsActive;

            _context.Update(existing);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existing = _context.Municipalities.FirstOrDefault(m => m.Id == id);
            if (existing == null)
            {
                return NotFound();
            }
            _context.Municipalities.Remove(existing);
            _context.SaveChanges();
            return NoContent();
        }

    }
}
