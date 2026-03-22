
using Homework2.Application.Contracts;
using Homework2.Application.DTOs.Authors;
using Homework2.Application.DTOs.Comments;
using Homework2.Domain.Entities;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;



namespace Homework2.Controllers
{
    [ApiController]
    [Route("Api/Comments")]
    public class CommentController:BaseController<Comment,CommentDTO>
    {
        private ICommentServices _commentServices => (ICommentServices)_services;
        public CommentController(ICommentServices services)
            : base((IBaseServices<Comment, CommentDTO>)services)
        {
        }

        //Get comments with specific word 
        [HttpGet("FindWord/{KeyWord}")]
        public async Task<ActionResult<List<CommentDTO>>> SearchInComments(string keyWord)
        {
            var responses = await _commentServices.SearchInCommentsAsync(keyWord); //select comment with specific word

            if (!responses.Success) 
                return NotFound($"Don't found comments with {keyWord}");//404


            return Ok(responses);//200
        }


        [HttpPatch("{id:int}")]
        public async Task<ActionResult> Patch(int id, JsonPatchDocument<CommentBodyDTO> patchDoc)
        {
            if (patchDoc is null) 
                return BadRequest("El documento de parche no puede ser nulo");

            var response = await _commentServices.PatchCommentAsync(id, patchDoc, ModelState);

            if (!response.Success)
                return response.StatusCode == 404 ? NotFound(response) : BadRequest(response);
            

            return Ok(response);//200

        }
    }
}
