
using Homework2.Application.Contracts;
using Homework2.Application.DTOs.Authors;
using Homework2.Application.DTOs.Books;
using Homework2.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Homework2.Controllers
{
    [ApiController]
    [Route("Api/Books")]         //Normally I use [Controller], but in this code I prefer to use [ApiController]
                                   // because with it I don't need to specify where the Post came from
    public class BookController: BaseController<Book,BookDTO>
    {
        private IBookServices _bookServices => (IBookServices)_services;
        public BookController(IBookServices services)
            :base((IBaseServices<Book, BookDTO>)services)
        {
        }


        //Get book with its comments
        [HttpGet("WithComments/{Id:int}")]
        public async Task<ActionResult<BookWithCommentsDTO>> GetBookWithComment(int id)
        {
            var responses = await _bookServices.GetBookWithCommentsAsync(id); //select Book with its comments

            if (!responses.Success)
                return NotFound(responses);//404

            return Ok(responses);//200
        }










        //---------------------------------------------
        //That's how I had it before using BaseController
        //---------------------------------------------





        /*
        public readonly ApplicationDbContext _DbContext;
        public readonly ILogger<BookControllers> _logger;
        public readonly IMapper _mapper;
        public BookControllers(ApplicationDbContext DbContext, ILogger<BookControllers> logger, IMapper mapper)
        {
            this._DbContext = DbContext;
            this._logger = logger;
            this._mapper = mapper;
        }



        [HttpGet]
        public async Task<IEnumerable<BookDTO>> Gets()
        {
            var book = await _DbContext.Books.ToListAsync<Book>();
            var bookDTOs = _mapper.Map<IEnumerable<BookDTO>>(book);
            
            return bookDTOs;
        }



        [HttpGet("{Id:int}", Name = "GetBook")] //A Get for specify Book with Api/Authors/#x
        public async Task<ActionResult<BookDTO>> Get(int id)
        {
            var book = await _DbContext.Books.FirstOrDefaultAsync(b => b.Id == id);

            var bookDTO = _mapper.Map<BookDTO>(book);

            if (bookDTO is null)
            {
                return BadRequest("Book doesn't exist");//401
            }

            return bookDTO;
        }

        [HttpPost] 
        public async Task<ActionResult> Post(Book book)
        {
            if (book == null) return BadRequest("The object book is null");//404 //I put it this condition because i had error amd wanna catch

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);//401 // Complement of condition  look for error expecific  
            }

            _DbContext.Add(book);
            await _DbContext.SaveChangesAsync();
            _logger.LogInformation("Book created");
            return CreatedAtRoute("GetBook", new {Id = book.Id}, book);//201
        }


        [HttpPut("{Id:int}")] //A put for specify Book with Api/Books/#x
        public async Task<ActionResult> Put(int id, Book book)
        {
            if (id != book.Id)
            {
                return BadRequest("The Ids not match");//401
            }

            _DbContext.Update(book);
            await _DbContext.SaveChangesAsync();
            return Ok("Update Done Corretly");
        }

        [HttpDelete("{Id:int}")] //A Delete for specify book with Api/Books/#x
        public async Task<ActionResult> Delete(int id)
        {
            var book = _DbContext.Books.FirstOrDefaultAsync(x => x.Id == id);

            if (book is null)
            {
                return NotFound("Not Found some book With Id");//404
            }

            var result = await _DbContext.Books.Where(a => a.Id == id).ExecuteDeleteAsync();
            _logger.LogInformation("Book Deleted");

            return CreatedAtRoute("GetBook", new { id = book.Id }, book);//201
        }
        */
    }
}
