using Homework2.DataAccess;
using Homework2.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Homework2.Controllers
{
    [ApiController]        //Normally I use [Controller], but in this code I prefer to use [ApiController]
                           // because with it I don't need to specify where the Post came from
    [Route("Api/Authors")]
    public class AuthorControllers:ControllerBase
    {
        public readonly DataDbContext _DbContext;
        public AuthorControllers(DataDbContext _DbContext)
        {
            this._DbContext = _DbContext;
        }



        [HttpGet]
        public async Task<List<Author>> Gets()
        {
            return await _DbContext.Authors.ToListAsync<Author>();
        }



        [HttpGet("{Id:int}")] //A Get for specify author with Api/Authors/#x
        public async Task<ActionResult<Author>> Get(int id)
        {
            var author = await _DbContext.Authors.FirstOrDefaultAsync(a => a.Id == id);

            if (author is null)
            {
                return BadRequest("Author doesn't exist");
            }

            return author;
        }

        [HttpPost]
        public async Task<ActionResult> Post(Author author)
        {
            _DbContext.Add(author);
            await _DbContext.SaveChangesAsync();
            return Ok("Author Creado");
        }


        [HttpPut("{Id:int}")] //Update specify Author with Api/Authors/#x
        public async Task<ActionResult> Put(int id, Author author)
        {
            if(id != author.Id)
            {
                return BadRequest("The Ids not match");
            }

            _DbContext.Update(author);
            await _DbContext.SaveChangesAsync();
            return Ok("Update Done Corretly");
        }

        [HttpDelete("{Id:int}")]   //Delete specify Author with Api/Authors/#x
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _DbContext.Authors.Where(a => a.Id == id).ExecuteDeleteAsync();

            if(result == 0)
            {
                return NotFound("Not Found some Author With Id");
            }

            return Ok("Author Deleted Correctly");
        }
    }
}
