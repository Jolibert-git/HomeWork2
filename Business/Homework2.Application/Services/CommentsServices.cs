using AutoMapper;
using Homework2.Application.Contracts;
using Homework2.Application.DTOs.Comments;
using Homework2.Application.Responses;
using Homework2.Domain.Entities;
using Homework2.Domain.Repository;
using Homework2.Infrastructur.Repositories;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Homework2.Application.Services
{
    public class CommentsServices: BaseServices<Comment,CommentDTO>, ICommentServices
    {
        public CommentsServices(
                              IMapper mapper,
                              UnitOfWork work,
                              IGenericRepository<Comment> repository
                              )
            : base(mapper, work, repository)
        {
        }

        public async Task<ApiResponses<List<CommentDTO>>> SearchInCommentsAsync(string keyWord)
        {
            var comments = await _work.Comment.SearchInComments(keyWord); //select comment with specific word

            if (comments is null || !comments.Any()) return ApiResponses<List<CommentDTO>>.ErrorResponse($"Don't found comments with {keyWord}");

            var commentsDTO = _mapper.Map<List<CommentDTO>>(comments);

            return ApiResponses<List<CommentDTO>>.SuccessResponse(commentsDTO, "Get Comments Successfull");//200
        }

        public async Task<ApiResponses<CommentBodyDTO>> PatchCommentAsync(int id, JsonPatchDocument<CommentBodyDTO> patchDoc, ModelStateDictionary modelState)
        {
            
            var comment = await _work.Comment.GetAsync(id);
            if (comment == null)
            {
                return ApiResponses<CommentBodyDTO>.ErrorResponse($"Comentario con id {id} no encontrado", 404);
            }

            
            var commentDTO = _mapper.Map<CommentDTO>(comment);
            var commentPatchDTO = _mapper.Map<CommentBodyDTO>(commentDTO);

            
            patchDoc.ApplyTo(commentPatchDTO, modelState);

            
            if (!modelState.IsValid)
            {
                return ApiResponses<CommentBodyDTO>.ErrorResponse("Error en la validación del parche", 400);
            }

            
            _mapper.Map(commentPatchDTO, commentDTO);
            _mapper.Map(commentDTO, comment);

            
            await _work.Complite();

            return ApiResponses<CommentBodyDTO>.SuccessResponse(commentPatchDTO, "Comentario actualizado exitosamente");
        }


    }
}
