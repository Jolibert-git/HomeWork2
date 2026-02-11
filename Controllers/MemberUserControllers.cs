using Homework2.DataAccess;
using Homework2.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Homework2.Controllers
{
    [ApiController]               //Normally I use [Controller], but in this code I prefer to use [ApiController]
                                  // because with it I don't need to specify where the Post came from
    [Route("Api/MemberUsers")]
    public class MemberUserControllers: ControllerBase
    {
        public readonly DataDbContext _DbContext;
        public MemberUserControllers(DataDbContext _DbContext)
        {
            this._DbContext = _DbContext;
        }


        [HttpGet]
        public async Task<List<MemberUser>> Gets()
        {
            return await _DbContext.MemberUsers.ToListAsync<MemberUser>();
        }


        [HttpGet("{Id:int}")]   //A Get for specify Member with Api/MemberUsers/#x
        public async Task<ActionResult<MemberUser>> Get(int id)
        {
            var memberUser = await _DbContext.MemberUsers.FirstOrDefaultAsync(b => b.Id == id);

            if (memberUser is null)
            {
                return BadRequest("MemberUser doesn't exist");
            }

            return memberUser;
        }

        [HttpPost]
        public async Task<ActionResult> Post(MemberUser memberUser)
        {
            _DbContext.Add(memberUser);
            await _DbContext.SaveChangesAsync();
            return Ok("MemberUser Creado");
        }


        [HttpPut("{Id:int}")] //A Put for specify Member with Api/MemberUsers/#x
        public async Task<ActionResult> Put(int id, MemberUser memberUser)
        {
            if (id != memberUser.Id)
            {
                return BadRequest("The Ids not match");
            }

            _DbContext.Update(memberUser);
            await _DbContext.SaveChangesAsync();
            return Ok("Update Done Corretly");
        }



        [HttpDelete("{Id:int}")] //A Delete for specify Member with Api/MemberUsers/#x
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _DbContext.MemberUsers.Where(a => a.Id == id).ExecuteDeleteAsync();

            if (result == 0)
            {
                return NotFound("Not Found some memberUser With Id");
            }

            return Ok("MemberUser Deleted Correctly");
        }

    }
    
}
