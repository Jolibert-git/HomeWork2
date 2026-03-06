using AutoMapper;
using Homework2.DataAccess;
using Homework2.DTOs;
using Homework2.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Homework2.Controllers
{
    //[ApiController]               //Normally I use [Controller], but in this code I prefer to use [ApiController]
    // because with it I don't need to specify where the Post came from
    [Route("Api/MemberUsers")]
    public class MemberUserControllers : BaseController<MemberUser, MemberUserDTO>
    {
        public MemberUserControllers(ApplicationDbContext context, ILogger<MemberUserControllers> logger, IMapper mapper)
            : base(mapper, logger, context)
        {
        }

    }

}



















        /*
        public readonly ApplicationDbContext _DbContext;
        public readonly ILogger<LoanControllers> _logger;
        public readonly IMapper _mapper;
        public MemberUserControllers(ApplicationDbContext DbContext, ILogger<LoanControllers> logger, IMapper mapper)
        {
            this._DbContext = DbContext;
            this._logger = logger;
            this._mapper = mapper;
        }


        [HttpGet]
        public async Task<IEnumerable<MemberUserDTO>> Gets()
        {
            var memberUser = await _DbContext.MemberUsers.ToListAsync<MemberUser>();

            var memberUserDTOs = _mapper.Map<IEnumerable<MemberUserDTO>>(memberUser);

            return memberUserDTOs;
        }


        [HttpGet("{Id:int}", Name = "GetMemberUser")]   //A Get for specify Member with Api/MemberUsers/#x
        public async Task<ActionResult<MemberUserDTO>> Get(int id)
        {
            var memberUser = await _DbContext.MemberUsers.FirstOrDefaultAsync(b => b.Id == id);

            var memberUserDTO = _mapper.Map<MemberUserDTO>(memberUser);

            if (memberUserDTO is null)
            {
                return BadRequest("MemberUser doesn't exist");//401
            }

            return memberUserDTO;
        }

        [HttpPost]
        public async Task<ActionResult> Post(MemberUser memberUser)
        {
            _DbContext.Add(memberUser);
            await _DbContext.SaveChangesAsync();
            _logger.LogInformation("Created MemberUser");
            return CreatedAtRoute("GetMemberUser", new {id = memberUser.Id}, memberUser);//201
        }


        [HttpPut("{Id:int}")] //A Put for specify Member with Api/MemberUsers/#x
        public async Task<ActionResult> Put(int id, MemberUser memberUser)
        {
            if (id != memberUser.Id)
            {
                return BadRequest("The Ids not match");//401
            }

            _DbContext.Update(memberUser);
            await _DbContext.SaveChangesAsync();
            _logger.LogInformation("UpdateMemberUser");

            return CreatedAtRoute("GetMemberUser", new { id = memberUser.Id }, memberUser);
        }



        [HttpDelete("{Id:int}")] //A Delete for specify Member with Api/MemberUsers/#x
        public async Task<ActionResult> Delete(int id)
        {
            var memberUser = _DbContext.MemberUsers.FirstOrDefaultAsync(x => x.Id == id);

            if (memberUser is null)
            {
                return NotFound("Not Found some memberUser With Id");
            }

            var result = await _DbContext.MemberUsers.Where(a => a.Id == id).ExecuteDeleteAsync();
            _logger.LogInformation("Created MemberUser");

            return CreatedAtRoute("GetMemberUser", new { id = memberUser.Id }, memberUser);//201
        }
    }
}
        */

    
    

