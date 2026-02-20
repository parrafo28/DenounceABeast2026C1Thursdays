using DenounceBeasts.API.Data;
using Microsoft.AspNetCore.Mvc;

namespace DenounceBeasts.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseController<T> : ControllerBase where T : class
    {
        public ApplicationDataContext Context;

        public BaseController(ApplicationDataContext context)
        {
            Context = context;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var entity = Context.Set<T>().Find(id);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var entities = Context.Set<T>().ToList();
            return Ok(entities);
        }

        [HttpPost]
        public IActionResult Create(T entity)
        {
            Context.Set<T>().Add(entity);
            Context.SaveChanges();
            return Ok(entity);
        }

        [HttpPut("{id}")]
        public IActionResult Update(T entity)
        {
            Context.Set<T>().Update(entity);
            Context.SaveChanges();
            return Ok(entity);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var entity = Context.Set<T>().Find(id);
            if (entity == null)
            {
                return NotFound();
            }
            Context.Set<T>().Remove(entity);
            Context.SaveChanges();
            return NoContent();
        }

    }
}
