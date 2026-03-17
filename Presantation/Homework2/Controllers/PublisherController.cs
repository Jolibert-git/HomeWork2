
using Homework2.Application.Contracts;
using Homework2.Application.DTOs.Publishers;
using Homework2.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Homework2.Controllers
{
    //[ApiController]    //Normally I use [Controller], but in this code I prefer to use [ApiController]
                       // because with it I don't need to specify where the Post came from

    [Route("Api/Publishers")]
    public class PublisherController: BaseController<Publisher,PublisherDTO>
    {
        private IPublisherServices _publisherServices => (IPublisherServices)_services;
        public PublisherController(IPublisherServices services)
            :base((IBaseServices<Publisher, PublisherDTO>)services)
        {
        }

        //looking for Publusher by contry

        [HttpGet("Contry/{contry}")]
        public async Task<ActionResult<List<PublisherDTO>>> GetByContry(string contry)
        {
            var responses = await _publisherServices.GetPublishersByCountryAsync(contry);//select specific Publishers from specific contry

            if (!responses.Success) 
                return NotFound("There aren't publisher from that contry");//400

            return Ok(responses);//200
        }











        //---------------------------------------------
        //That's how I had it before using BaseController
        //---------------------------------------------



        //now i watch that this Controller don't had Mapper
        /*
        public readonly ApplicationDbContext _DbContext;
        public readonly ILogger<LoanControllers> logger;
        public PublisherControllers(ApplicationDbContext _DbContext, ILogger<LoanControllers> _logger)
        {
            this._DbContext = _DbContext;
            this.logger = _logger;
        }

        [HttpGet]
        public async Task<List<Publisher>> Gets()
        {
            return await _DbContext.Publishers.ToListAsync<Publisher>();
        }


        [HttpGet("{Id:int}", Name = "GetPublisher")]  //A Get for specify Publisher with Api/Publishers/#x
        public async Task<ActionResult<Publisher>> Get(int id)
        {
            var publisher = await _DbContext.Publishers.FirstOrDefaultAsync(a => a.Id == id);

            if (publisher is null)
            {
                return BadRequest("Publihsher doesn't exist");//401
            }

            return publisher;
        }

        [HttpPost]
        public async Task<ActionResult> Post(Publisher publisher)
        {
            _DbContext.Add(publisher);
            await _DbContext.SaveChangesAsync();
            logger.LogInformation("Publisher Created");
            return CreatedAtRoute("GetPublisher", new {id = publisher.Id}, publisher);//201
        }


        [HttpPut("{Id:int}")]  //A Put for specify Publisher with Api/Publishers/#x
        public async Task<ActionResult> Put(int id, Publisher publisher)
        {
            if (id != publisher.Id)
            {
                return BadRequest("The Ids not match");//401
            }

            _DbContext.Update(publisher);
            await _DbContext.SaveChangesAsync();
            logger.LogInformation("Publisher Update");
            return CreatedAtRoute("GetPublisher", new {id = publisher.Id}, publisher);//201
        }

        [HttpDelete("{Id:int}")] //A DElete for specify Publisher with Api/Publishers/#x
        public async Task<ActionResult> Delete(int id)
        {
            var publisher = _DbContext.Publishers.FirstOrDefaultAsync(x => x.Id == id);

            if (publisher is null)
            {
                return NotFound("Not Found some Publisher With Id");//404
            }
            var result = await _DbContext.Publishers.Where(a => a.Id == id).ExecuteDeleteAsync();
            logger.LogInformation("Publisher deleted");
            return CreatedAtRoute("GetPublisher", new {id = publisher.Id}, publisher);//201
        }
        */
    }
}
