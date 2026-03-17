using Homework2.Application.DTOs.Comments;
using Homework2.Application.Responses;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc.ModelBinding;


namespace Homework2.Application.Contracts
{
    public interface ICommentServices
    {
        Task<ApiResponses<List<CommentDTO>>> SearchInCommentsAsync(string keyWord);
        Task<ApiResponses<CommentBodyDTO>> PatchCommentAsync(int id, JsonPatchDocument<CommentBodyDTO> patchDoc, ModelStateDictionary modelState);
    }
}
