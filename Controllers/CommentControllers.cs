using AutoMapper;
using Homework2.DataAccess;
using Homework2.DTOs;
using Homework2.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;


namespace Homework2.Controllers
{
    [Route("Api/Comments")]
    public class CommentControllers:BaseController<Comment,CommentDTO>
    {
        public CommentControllers(ApplicationDbContext context, ILogger<CommentControllers> logger, IMapper mapper)
            : base(mapper, logger, context)
        {
        }


        [HttpPatch("{id:int}")]
        public async Task<ActionResult> Patch(int id, JsonPatchDocument<CommentPatchDTO> PatchDoc )
        {
            if (PatchDoc is null)  return BadRequest();//400

            var comment = await _context.Comments.FirstOrDefaultAsync(c => c.Id == id);


            if (comment is null) return NotFound();//404
            

            var commentDTO = _mapper.Map<CommentDTO>(comment);  //yes because i used hierachy, Comment to CommentDTO to CommentPatchDTO

            var commentPatchDTO = _mapper.Map<CommentPatchDTO>(commentDTO);

            PatchDoc.ApplyTo(commentPatchDTO, ModelState);

            //var isValidate = TryValidateModel(commentPatchDTO);

            if (!TryValidateModel(commentPatchDTO)) return ValidationProblem();
            
            _mapper.Map(commentPatchDTO, commentDTO);
            _mapper.Map(commentDTO, comment);

            await _context.SaveChangesAsync();

            return NoContent();//201
            
        }
    }
}
