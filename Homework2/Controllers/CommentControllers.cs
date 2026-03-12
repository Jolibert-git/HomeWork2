using AutoMapper;
using Homework2.Domain.Entities;
using Homework2.DTOs;
using Homework2.Infrastructur.Repositories;
using Homework2.Persistences.DataAccess;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Homework2.Controllers
{
    [Route("Api/Comments")]
    public class CommentControllers:BaseController<Comment,CommentDTO>
    {
        public CommentControllers( IMapper mapper, 
                                   UnitOfWork work, 
                                   GenericRepository<Comment> repository
                                 )
            : base(mapper, work, repository)
        {
        }

        //Get comments with specific word 
        [HttpGet("FindWord/{KeyWord}")]
        public async Task<ActionResult<List<CommentDTO>>> SearchInComments(string keyWord)
        {
            var comments = await _work.Comment.SearchInComments(keyWord); //select comment with specific word

            if (comments is null) return NotFound($"Don't found comments with {keyWord}");

            var commentsDTO = _mapper.Map<List<CommentDTO>>(comments);

            return Ok(commentsDTO);//200
        }


        [HttpPatch("{id:int}")]
        public async Task<ActionResult> Patch(int id, JsonPatchDocument<CommentBodyDTO> PatchDoc )
        {
            if (PatchDoc is null)  return BadRequest();//400

            var comment = await _work.Comment.GetAsync(id);//_context.Comments.FirstOrDefaultAsync(c => c.Id == id);


            if (comment is null) return NotFound();//404
            

            var commentDTO = _mapper.Map<CommentDTO>(comment);  //yes because i used hierachy, Comment to CommentDTO to CommentPatchDTO

            var commentPatchDTO = _mapper.Map<CommentBodyDTO>(commentDTO);

            PatchDoc.ApplyTo(commentPatchDTO, ModelState);

            //var isValidate = TryValidateModel(commentPatchDTO);

            if (!TryValidateModel(commentPatchDTO)) return ValidationProblem();
            
            _mapper.Map(commentPatchDTO, commentDTO);
            _mapper.Map(commentDTO, comment);

            await _work.Complite();//_context.SaveChangesAsync();

            return NoContent();//201
            
        }
    }
}
