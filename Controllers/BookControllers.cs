using Homework2.DataAccess;
using Homework2.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Homework2.Controllers
{
    [ApiController]       
    [Route("Api/Books")]
    public class BookControllers: ControllerBase
    {
        public readonly DataDbContext _DbContext;
        public BookControllers(DataDbContext _DbContext)
        {
            this._DbContext = _DbContext;
        }



        [HttpGet]
        public async Task<List<Book>> Gets()
        {
            return await _DbContext.Books.ToListAsync<Book>();
        }



        [HttpGet("{Id:int}")]
        public async Task<ActionResult<Book>> Get(int id)
        {
            var book = await _DbContext.Books.FirstOrDefaultAsync(b => b.Id == id);

            if (book is null)
            {
                return BadRequest("Book doesn't exist");
            }

            return book;
        }

        [HttpPost]
        public async Task<ActionResult> Post(Book book)
        {
            if (book == null) return BadRequest("El objeto Book es nulo");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Esto te dirá EXACTAMENTE qué campo está fallando
            }

            _DbContext.Add(book);
            await _DbContext.SaveChangesAsync();
            return Ok("Book Creado");
        }


        [HttpPut("{Id:int}")]
        public async Task<ActionResult> Put(int id, Book book)
        {
            if (id != book.Id)
            {
                return BadRequest("The Ids not match");
            }

            _DbContext.Update(book);
            await _DbContext.SaveChangesAsync();
            return Ok("Update Done Corretly");
        }

        [HttpDelete("{Id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _DbContext.Books.Where(a => a.Id == id).ExecuteDeleteAsync();

            if (result == 0)
            {
                return NotFound("Not Found some book With Id");
            }

            return Ok("Book Deleted Correctly");
        }
    }
}
