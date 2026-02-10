using Homework2.DataAccess;
using Homework2.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Homework2.Controllers
{
    [ApiController]
    [Route("Api/Publisher")]
    public class PublisherControllers: ControllerBase
    {
        public readonly DataDbContext _DbContext;
        public PublisherControllers(DataDbContext _DbContext)
        {
            this._DbContext = _DbContext;
        }

        [HttpGet]
        public async Task<List<Publisher>> Gets()
        {
            return await _DbContext.Publishers.ToListAsync<Publisher>();
        }



        [HttpGet("{Id:int}")]
        public async Task<ActionResult<Publisher>> Get(int id)
        {
            var publisher = await _DbContext.Publishers.FirstOrDefaultAsync(a => a.Id == id);

            if (publisher is null)
            {
                return BadRequest("Author doesn't exist");
            }

            return publisher;
        }

        [HttpPost]
        public async Task<ActionResult> Post(Publisher publisher)
        {
            _DbContext.Add(publisher);
            await _DbContext.SaveChangesAsync();
            return Ok("Publisher Creado");
        }


        [HttpPut("{Id:int}")]
        public async Task<ActionResult> Put(int id, Publisher publisher)
        {
            if (id != publisher.Id)
            {
                return BadRequest("The Ids not match");
            }

            _DbContext.Update(publisher);
            await _DbContext.SaveChangesAsync();
            return Ok("Update Done Corretly");
        }

        [HttpDelete("{Id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _DbContext.Publishers.Where(a => a.Id == id).ExecuteDeleteAsync();

            if (result == 0)
            {
                return NotFound("Not Found some Publisher With Id");
            }

            return Ok("Publisher Deleted Correctly");
        }
    }
}
