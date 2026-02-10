using Homework2.DataAccess;
using Homework2.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Homework2.Controllers
{
    [ApiController]
    [Route("Api/Loans")]
    public class LoanControllers: ControllerBase
    {
        public readonly DataDbContext _DbContext;
        public LoanControllers(DataDbContext _DbContext)
        {
            this._DbContext = _DbContext;
        }



        [HttpGet]
        public async Task<List<Loan>> Gets()
        {
            return await _DbContext.Loans.ToListAsync<Loan>();
        }



        [HttpGet("{Id:int}")]
        public async Task<ActionResult<Loan>> Get(int id)
        {
            var loan = await _DbContext.Loans.FirstOrDefaultAsync(l => l.Id == id);

            if (loan is null)
            {
                return BadRequest("Loan doesn't exist");
            }

            return loan;
        }

        [HttpPost]
        public async Task<ActionResult> Post(Loan loan)
        {
            _DbContext.Add(loan);
            await _DbContext.SaveChangesAsync();
            return Ok("Loan Creado");
        }


        [HttpPut("{Id:int}")]
        public async Task<ActionResult> Put(int id, Loan loan)
        {
            if (id != loan.Id)
            {
                return BadRequest("The Ids not match");
            }

            _DbContext.Update(loan);
            await _DbContext.SaveChangesAsync();
            return Ok("Update Done Corretly");
        }

        [HttpDelete("{Id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _DbContext.Loans.Where(a => a.Id == id).ExecuteDeleteAsync();

            if (result == 0)
            {
                return NotFound("Not Found some Loan With Id");
            }

            return Ok("Loan Deleted Correctly");
        }
    }
}
