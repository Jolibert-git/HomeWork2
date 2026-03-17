using Homework2.Application.Contracts;
using Homework2.Application.Responses;
using Homework2.Domain.Entities;
using Microsoft.AspNetCore.Mvc;


namespace Homework2.Controllers
{
    [ApiController]
    public abstract class BaseController<TEntities,TDTO>: ControllerBase
        where TEntities: class, IHasId
        where TDTO : class
    {

        public readonly IBaseServices<TEntities,TDTO> _services;

        public BaseController( IBaseServices<TEntities, TDTO> services)
        {
            this._services = services;
        }

        [HttpGet]
        public async  Task<ActionResult<ApiResponses<IEnumerable<TDTO>>>> GetAllAsync()
        {
            var responses = await _services.GetAllEntityAsync();

            if (!responses.Success) return BadRequest("Error with null value ");

            return Ok(responses);
        }

        [HttpGet("{Id:int}")]
        public async Task <ActionResult<ApiResponses<TDTO>>> GetAsync(int id)
        {
            var response = await _services.GetEntityByIdAsync(id);//GetAsync(id);//_context.Set<TEntities>().FirstOrDefaultAsync(v => v.Id == id);
           
            if(!response.Success)
            {
                return NotFound(response);//404
            }

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponses<TDTO>>> PostAsync(TEntities entity)
        {
            var response = await _services.PostEntityAsync(entity);

            if (!response.Success) return BadRequest(response);

            return CreatedAtAction("Get", new { id = entity.Id }, response); //201    
        }

        [HttpPut("{Id:int}")]
        public async Task<ActionResult<ApiResponses<TDTO>>> UpdateAsync(int id, TEntities entity)
        {
            if (id != entity.Id)
                return BadRequest($"Propierty not match with Ids: {id}");//401
            

            var response = await _services.UpdateEntityAsync(id,entity);//UpdateAsync(id,entity);

            if (response.Success)
                return NotFound(response);

            return CreatedAtAction("Get", new { id = entity.Id }, response); //201 
        }

        [HttpDelete("{Id:int}")]
        public async Task<ActionResult<ApiResponses<TDTO>>> DeleteAsync(int id)
        {
            var response = await _services.DeleteEntityAsync(id);//DeleteAsync(id);//_context.Set<TEntities>().Where(e => e.Id == id).ExecuteDeleteAsync();

            if (!response.Success)
            {
                return NotFound($"Not found entity with Id: {response}");//404
            }

            return Ok(response);//200
        }
    }
}
