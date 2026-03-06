using AutoMapper;
using Homework2.DataAccess;
using Homework2.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Homework2.Controllers
{
    [ApiController]
    public abstract class BaseController<TEntities,TDTO>: ControllerBase
        where TEntities: class, IHasId
        where TDTO : class
    {
        public readonly IMapper _mapper;
        public readonly ILogger<BaseController<TEntities, TDTO>> _logger;
        public readonly ApplicationDbContext _context;

        public BaseController(IMapper mapper, ILogger<BaseController<TEntities, TDTO>>logger, ApplicationDbContext context)
        {
            this._logger = logger;
            this._mapper = mapper;
            this._context = context;
        }

        [HttpGet]
        public async  Task<IEnumerable<TDTO>> Get()
        {
            var varieble = await _context.Set<TEntities>().ToListAsync();
            var variebleDTO = _mapper.Map<IEnumerable<TDTO>>(varieble);

            return variebleDTO;
        }

        [HttpGet("{Id:int}")]
        public async Task <ActionResult<TDTO>> Get(int id)
        {
            var varieble = await _context.Set<TEntities>().FirstOrDefaultAsync(v => v.Id == id);
            var variebleDTO = _mapper.Map<TDTO>(varieble);

            if(variebleDTO is null)
            {
                return NotFound($"Propierty not found with Id: {id}");//404
            }

            return variebleDTO;
        }

        [HttpPost]
        public async Task<ActionResult> Post(TEntities entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();

            return NoContent();//204 //CreatedAtRoute($"Get", new { Id = entity.Id }, entity);//201    
        }

        [HttpPut("{Id:int}")]
        public async Task<ActionResult> Delete(int id, TEntities entity)
        {
            if (id != entity.Id)
            {
                return BadRequest($"Propierty not match with Ids: {id}");//401
            }

            _context.Update(entity);
            await _context.SaveChangesAsync();
            return NoContent();//204
        }

        [HttpDelete("{Id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var resul = await _context.Set<TEntities>().Where(e => e.Id == id).ExecuteDeleteAsync();

            if (resul == 0)
            {
                return NotFound($"Not found entity with Id: {id}");//404
            }

            return NoContent();//204
        }
    }
}
