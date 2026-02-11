using Homework2.DataAccess;
using Homework2.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Homework2.Controllers
{
    [ApiController]       
    [Route("Api/Books")]//Normally I use [Controller], but in this code I prefer to use [ApiController]
                        // because with it I don't need to specify where the Post came from
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



        [HttpGet("{Id:int}")] //A Get for specify Book with Api/Authors/#x
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
            if (book == null) return BadRequest("The object book is null"); //I put it this condition because i had error amd wanna catch

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Complement of condition  look for error expecific  
            }

            _DbContext.Add(book);
            await _DbContext.SaveChangesAsync();
            return Ok("Book Creado");
        }


        [HttpPut("{Id:int}")] //A put for specify Book with Api/Books/#x
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

        [HttpDelete("{Id:int}")] //A Delete for specify book with Api/Books/#x
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
