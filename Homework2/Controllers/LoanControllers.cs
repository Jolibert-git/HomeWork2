using AutoMapper;
using Homework2.Domain.Entities;
using Homework2.DTOs;
using Homework2.Infrastructur.Repositories;
using Homework2.Persistences.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace Homework2.Controllers
{
    [ApiController]      //Normally I use [Controller], but in this code I prefer to use [ApiController]
                         // because with it I don't need to specify where the Post came from
    [Route("Api/Loans")]
    public class LoanControllers: BaseController<Loan,LoanDTO>
    {
        public LoanControllers( IMapper mapper, 
                                UnitOfWork work, 
                                GenericRepository<Loan> repository
                              )
            :base(mapper,work, repository)
        {
        }

        //Get Loan with specific User
        [HttpGet("User/{Id:int}")]
        public async Task<ActionResult<List<LoanDTO>>> GetLoanByUser(int id)
        {
            var loan = await _work.Loan.GetLoansByUserIdAsync(id);  //select Loan with specific User

            if (loan is null) return NotFound($"Not found that User's Loan");//404

            var loanDTO = _mapper.Map<List<LoanDTO>>(loan);

            return Ok(loanDTO);//200
        }








        //---------------------------------------------
        //That's how I had it before using BaseController
        //---------------------------------------------





        /*
        public readonly ApplicationDbContext _DbContext;
        public readonly ILogger<LoanControllers> _logger;
        public readonly IMapper _mapper;
        public LoanControllers(ApplicationDbContext _DbContext, ILogger<LoanControllers> logger, IMapper mapper)
        {
            this._DbContext = _DbContext;
            this._logger = logger;
            this._mapper = mapper;
        }



        [HttpGet] 
        public async Task<IEnumerable<LoanDTO>> Gets()
        {
            var loans = await _DbContext.Loans.ToListAsync<Loan>();

            var loanDTOs = _mapper.Map<IEnumerable<LoanDTO>>(loans);
            return loanDTOs;
        }



        [HttpGet("{Id:int}", Name = "GetLoan")]   //A Get for specify Loan with Api/Loans/#x
        public async Task<ActionResult<LoanDTO>> Get(int id)
        {
            var loan = await _DbContext.Loans.FirstOrDefaultAsync(l => l.Id == id);

            var loanDTO = _mapper.Map<LoanDTO>(loan); 

            if (loanDTO is null)
            {
                return BadRequest("Loan doesn't exist");//401
            }

            return loanDTO;
        }

        [HttpPost]
        public async Task<ActionResult> Post(Loan loan)
        {
            _DbContext.Add(loan);
            await _DbContext.SaveChangesAsync();
            _logger.LogInformation("Loan Created");
            return CreatedAtRoute("GetLoan", new {id = loan.Id}, loan);//201
        }


        [HttpPut("{Id:int}")] //A put for specify Loan with Api/Loans/#x
        public async Task<ActionResult> Put(int id, Loan loan)
        {
            if (id != loan.Id)
            {
                return BadRequest("The Ids not match");//401
            }

            _DbContext.Update(loan);
            await _DbContext.SaveChangesAsync();
            _logger.LogInformation("Update Loan");
            return CreatedAtRoute("GetLoan", new {id = loan.Id }, loan);//201
        }

        [HttpDelete("{Id:int}")] //A Delete for specify Loan with Api/Loans/#x
        public async Task<ActionResult> Delete(int id)
        {
            var loan = _DbContext.Loans.FirstOrDefaultAsync(x => x.Id == id);

            if (loan is null)
            {
                return NotFound("Not Found some Loan With Id");//404
            }

            var result = await _DbContext.Loans.Where(a => a.Id == id).ExecuteDeleteAsync();
            _logger.LogInformation("Deleted Loan");
            return CreatedAtRoute("GetLoan", new {id = loan.Id}, loan);//201
        }
        */
    }
}
