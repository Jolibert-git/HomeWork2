using Homework2.Application.Contracts;
using Homework2.Application.DTOs.Authors;
using Homework2.Application.Responses;
using Homework2.Domain.Entities;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Homework2.Controllers
{
                                     //Normally I use [Controller], but in this code I prefer to use [ApiController]
    [ApiController]                  // because with it I don't need to specify where the Post came from
    [Route("Api/Authors")]
    public class AuthorController : BaseController<Author, AuthorDTO>
    {
        private IAuthorServices _authorService => (IAuthorServices)_services; //I get of owner class or father class
        public AuthorController(IAuthorServices services)
            :base((IBaseServices<Author, AuthorDTO>)services)
        {
        }

        // Get Author with hir books 
        [HttpGet("WithBooks/{Id:int}")]
        public async Task<ActionResult<AuthorWithBooksDTO>> GetAuthorWithBooks(int id)
        {
            var responses = await _authorService.GetAuthorWithBooksAsync(id);//select Author with him books 

            if (!responses.Success) 
                return NotFound($"this author doesn't exist {responses}");

            return Ok(responses);
        }




        [HttpPatch("{Id:int}")]
        public async Task<ActionResult<ApiResponses<AuthorPatchDTO>>> Patch(int id, JsonPatchDocument<AuthorPatchDTO> patchDoc)
        {

            if (patchDoc is null) 
                return BadRequest("El documento de parche no puede ser nulo");

          
            var response = await _authorService.PatchAuthorAsync(id, patchDoc, ModelState);

            if (!response.Success)
                 return response.StatusCode == 404 ? NotFound(response) : BadRequest(response);
            

            return Ok(response);








            //if (PatchDoc is null) return BadRequest();//400


            //var author = _work.Author.GetAsync(id);//_context.Authors.FirstOrDefault(a => a.Id == id);

            //var authorPatchDTO = _mapper.Map<AuthorPatchDTO>(author);//remain here i don't used hierarchy like Author to AuthorDTO to AuthorPatchDTO

            //if (author is null) return NotFound();//404


            //PatchDoc.ApplyTo(authorPatchDTO, ModelState);

            //if (!TryValidateModel(authorPatchDTO)) return ValidationProblem();//400

            //await _mapper.Map(authorPatchDTO,author);

            //await _work.Complite();//_context.SaveChangesAsync();

            //return NoContent();//204
        }

        


    }
}



//---------------------------------------------
//That's how I had it before using BaseController and layer aquitecture 




/*
public readonly ApplicationDbContext _DbContext;
public readonly ILogger<AuthorControllers> logger;   // I used logger for practice, now not is needs
public readonly IMapper mapper;
public AuthorControllers(ApplicationDbContext _DbContext,ILogger<AuthorControllers> _logger, IMapper _mapper)
{
    this._DbContext = _DbContext;
    this.logger = _logger;
    this.mapper = _mapper;
}



[HttpGet]
public async Task<IEnumerable<AuthorDTO>> GetAthors()
{
    var authors = await _DbContext.Authors.ToListAsync<Author>();
    var authorsDTO = mapper.Map<IEnumerable<AuthorDTO>>(authors);

    return authorsDTO;

    //---------------------------------------------------
    //The way manual is like that but i used Pakege because is more fast and easy. Name of Library is AutoMapper
    /*
    var authorsDTO = authors.Select(authors => new AuthorDTO //authorsDTO is IEnumerable because Selcet and other function of Lambda always return IEnumerable
    {
        Id = authors.Id,
        FullName = $"{authors.Name} {authors.LastName}"
    });
    return authorsDTO;
    */
/*
}
*/

/*

[HttpGet("{Id:int}", Name = "GetAuthor")] //A Get for specify author with Api/Authors/#x
public async Task<ActionResult<AuthorDTO>> GetAthor(int id)
{


    var author = await _DbContext.Authors.FirstOrDefaultAsync(a => a.Id == id);
    var authorDTO = mapper.Map<AuthorDTO>(author);

    if (authorDTO is null)
    {
        logger.LogWarning("The Author not found");
        return NotFound("Author not found"); //404
    }

    return authorDTO;
}

[HttpPost]
public async Task<ActionResult> Post(Author author)
{
    _DbContext.Add(author);
    await _DbContext.SaveChangesAsync();
    return CreatedAtRoute("GetAuthor", new {Id = author.Id}, author);//201
}


[HttpPut("{Id:int}")] //Update specify Author with Api/Authors/#x
public async Task<ActionResult> Put(int id, Author author)
{
    if(id != author.Id)
    {
        logger.LogWarning("Author Id and Id not macth ");
        return BadRequest("The Ids not match");//401
    }

    _DbContext.Update(author);
    await _DbContext.SaveChangesAsync();
    return NoContent(); //204
}


//Note, no is normally use delete because is loser info, the commun is create atributte bolean like astive=true/false
//
[HttpDelete("{Id:int}")]   //Delete specify Author with Api/Authors/#x
public async Task<ActionResult> Delete(int id)
{
    var author = await _DbContext.Authors.FirstOrDefaultAsync(x => x.Id == id);

    if(author is null)
    {
        logger.LogWarning("Author not found whet user try to delete");
        return NotFound("Not Found some Author With Id"); //401
    }
    var result = await _DbContext.Authors.Where(a => a.Id == id).ExecuteDeleteAsync();


    logger.LogInformation("Author Deleted");
    return NoContent();//204
}

}
}
*/