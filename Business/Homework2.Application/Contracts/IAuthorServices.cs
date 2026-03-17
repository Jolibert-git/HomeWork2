using Homework2.Application.DTOs.Authors;
using Homework2.Application.Responses;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc.ModelBinding;


namespace Homework2.Application.Contracts
{
    public interface IAuthorServices
    {
        Task<ApiResponses<AuthorWithBooksDTO>> GetAuthorWithBooksAsync(int id);
        Task<ApiResponses<AuthorPatchDTO>> PatchAuthorAsync(int id, JsonPatchDocument<AuthorPatchDTO> patchDoc, ModelStateDictionary modelState);
    }
}
